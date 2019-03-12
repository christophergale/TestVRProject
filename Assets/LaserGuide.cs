using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGuide : MonoBehaviour {

    public Vector3[] points;

    private LineRenderer lineRenderer;

    public Laser laserToCheck;
    public float tolerance = 0.5f;

	// Use this for initialization
	void Start () {
        lineRenderer = GetComponent<LineRenderer>();
        UpdateLine();
	}

    private void Update()
    {
        CheckLaserPosition();
    }

    public void UpdateLine()
    {
        lineRenderer.positionCount = 0;

        for (int i = 0; i < points.Length; i++)
        {
            lineRenderer.positionCount += 1;
            lineRenderer.SetPosition(i, points[i]);
        }
    }

    void CheckLaserPosition()
    {
        for (int i = 0; i < points.Length; i++)
        {
            if (Vector3.Magnitude(points[i] - laserToCheck.hits[i].point) < tolerance)
            {
                Debug.Log(i.ToString() + " is matching!");
            }
        }
    }
}
