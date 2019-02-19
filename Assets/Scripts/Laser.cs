using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    LineRenderer line;
    public float laserLength;
    List<Ray> rays;
    List<RaycastHit> hits;

	// Use this for initialization
	void Start () {
        line = GetComponent<LineRenderer>();
        rays = new List<Ray>();
        hits = new List<RaycastHit>();
	}

    // Update is called once per frame
    void Update()
    {
        FireRay(0, transform.position, transform.forward);

        line.positionCount = rays.Count + 1;

        int i = 0;
        line.SetPosition(i, rays[i].origin);
        line.SetPosition(i + 1, hits[i].point);
        line.SetPosition(i + 2, rays[i + 1].GetPoint(100));

    }

    void FireRay(int rayIndex, Vector3 origin, Vector3 direction)
    {
        rays.Insert(rayIndex, new Ray(origin, direction));
        hits.Insert(rayIndex, new RaycastHit());
        CheckReflection(rayIndex);
    }

    void CheckReflection(int rayIndex)
    {
        RaycastHit currentHit = hits[rayIndex];

        if (Physics.Raycast(rays[rayIndex], out currentHit))
        {
            if (currentHit.collider.GetComponent<Reflector>())
            {
                FireRay(1, currentHit.point, Vector3.Reflect(rays[0].direction, currentHit.normal));
            }
        }
    }
}
