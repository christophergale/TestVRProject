using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    LineRenderer line;


    /// <summary>
    /// The maximum number of possible reflections.
    /// </summary>
    [Tooltip("The maximum number of possible reflections.")] public int maximumReflections = 2;

    Ray[] rays;
    RaycastHit[] hits;
    public int reflections = 0;

	// Use this for initialization
	void Start () {
        // Get a reference to the LineRenderer component
        line = GetComponent<LineRenderer>();

        // Create arrays for both our Rays and our RaycastHits
        // The rays array is 1 greater than the maximum number of possible reflections
        rays = new Ray[maximumReflections + 1]; // 3
        // The hits array is the same size as the maximum number of possible reflections
        hits = new RaycastHit[maximumReflections + 1]; // 2
	}

    // Update is called once per frame
    void Update()
    {
        // First we fire a ray, passing in an index of 0 as it is our first ray
        // We also pass in the origin point of the ray (the transform.position of the laser) and the direction (forward)
        FireRay(0, transform.position, transform.forward);

        UpdateLine();
    }

    void FireRay(int rayIndex, Vector3 origin, Vector3 direction)
    {
        // Create a new ray at the index passed in, from the origin passed in, in the direction passed in
        rays[rayIndex] = new Ray(origin, direction);
        // Create a new RaycastHit at the index passed in
        hits[rayIndex] = new RaycastHit();

        // Call CheckReflection and pass in the rayIndex
        CheckReflection(rayIndex);
    }

    void CheckReflection(int rayIndex)
    {
        // Update the reflections count to be 1 greater than the rayIndex
        reflections = rayIndex;

        // Cast the ray at rayIndex and store its hit info in that same index of the hits array
        if (Physics.Raycast(rays[rayIndex], out hits[rayIndex]))
        {
            // If the ray hits a collider that has a Reflector component attached
            if (hits[rayIndex].collider.GetComponent<Reflector>())
            {
                // Fire a new ray, this time with the index of rayIndex + 1, from the point at which the ray hit the collider, in the direction of reflection
                FireRay(rayIndex + 1, hits[rayIndex].point, Vector3.Reflect(rays[rayIndex].direction, hits[rayIndex].normal));
            }

            //if (hits[rayIndex].collider.GetComponent<Switch>() && hits[rayIndex].collider.GetComponent<Switch>().switchType == Switch.SwitchType.Laser)
            //{
            //    hits[rayIndex].collider.GetComponent<Switch>().activated = true;
            //}

            if (hits[rayIndex].collider.GetComponent<LaserCheck>())
            {
                hits[rayIndex].collider.GetComponent<LaserCheck>().activated = true;
            }
        }
    }

    void UpdateLine()
    {
        // There will always be 2 more positions on the LineRenderer than there are reflections
        line.positionCount = reflections + 2;

        // Create an array of Vector3 linePositions that is also 2 greater than the reflections count
        Vector3[] linePositions = new Vector3[reflections + 2];

        // The first position will always be at the 0 index of the linePositions array and will always be the origin point of the first ray
        linePositions[0] = rays[0].origin;

        // Loop through the subsequent reflection points (from 1) and assign their position to the linePositions array
        for (int i = 1; i <= reflections; i++)
        {
            linePositions[i] = hits[i - 1].point;
        }

        // The final point (reflections + 1) is set to 10 units along the final ray
        linePositions[reflections + 1] = rays[reflections].GetPoint(10.0f);

        // Loop through the LineRenderer positions and assign them accordingly
        for (int i = 0; i < reflections + 1; i++)
        {
            line.SetPosition(i, linePositions[i]);
        }

        // Set the position of the final point of the LineRenderer
        line.SetPosition(reflections + 1, linePositions[reflections + 1]);
    }
}
