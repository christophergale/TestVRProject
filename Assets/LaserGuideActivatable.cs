using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGuideActivatable : Activatable {

    public Vector3[] points;

    private LineRenderer lineRenderer;

    public Laser laserToCheck;
    public float tolerance = 0.5f;

	// Use this for initialization
	void Start () {
        lineRenderer = GetComponent<LineRenderer>();
        UpdateLine();
	}

    public override void Update()
    {
        base.Update();

        activated = CheckLaserPosition();
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

    bool CheckLaserPosition()
    {
        bool completedCheck = false;

        for (int i = 0; i < points.Length; i++)
        {
            if (Vector3.Magnitude(points[i] - laserToCheck.hits[i].point) < tolerance)
            {
                completedCheck = true;
            }
            else
            {
                completedCheck = false;
                break;
            }
        }

        return completedCheck;
    }
}
