using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combiner : CliveClass {

    Ray combinedRay;
    LineRenderer line;

    public bool red;
    public bool green;
    public bool blue;

    public Color laserColor;

    public bool powered = false;

	// Use this for initialization
	void Start () {
        line = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (powered)
        {
            line.enabled = true;

            combinedRay = new Ray(transform.position, Vector3.forward);

            line.SetPosition(0, combinedRay.origin);
            line.SetPosition(1, combinedRay.GetPoint(10.0f));

            line.startColor = line.endColor = CheckCombinedColor();
        }
        else
        {
            line.enabled = false;
        }
	}

    Color CheckCombinedColor()
    {
        if (red)
            laserColor = Color.red;

        if (green)
            laserColor = Color.green;

        if (blue)
            laserColor = Color.blue;

        if (red && green)
            laserColor = Color.yellow;

        if (red && blue)
            laserColor = Color.magenta;

        if (green && blue)
            laserColor = Color.cyan;

        if (red && green && blue)
            laserColor = Color.white;

        return laserColor;
    }
}
