using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combiner : CliveClass {

    LineRenderer line;
    Laser laser;

    public bool red;
    public bool green;
    public bool blue;

    public Laser.LaserColor laserColor;

    public bool powered = false;

	// Use this for initialization
	void Start () {
        laser = gameObject.AddComponent<Laser>();
        line = gameObject.AddComponent<LineRenderer>();
        laser.line = line;

        line.material = Clive.instance.laserMaterial;
        line.startWidth = line.endWidth = 0.03f;
	}
	
	// Update is called once per frame
	void Update () {
        laser.enabled = line.enabled = powered;
        laser.laserColor = CheckCombinedColor();
	}

    Laser.LaserColor CheckCombinedColor()
    {
        if (red)
            laserColor = Laser.LaserColor.Red;

        if (green)
            laserColor = Laser.LaserColor.Green;

        if (blue)
            laserColor = Laser.LaserColor.Blue;

        if (red && green)
            laserColor = Laser.LaserColor.Yellow;

        if (red && blue)
            laserColor = Laser.LaserColor.Magenta;

        if (green && blue)
            laserColor = Laser.LaserColor.Cyan;

        if (red && green && blue)
            laserColor = Laser.LaserColor.White;

        return laserColor;
    }
}
