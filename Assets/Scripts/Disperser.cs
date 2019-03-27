using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disperser : CliveClass {

    public int dispersalCount = 3;
    Laser[] lasers;
    LineManager lineManager;

    public bool colorSplit = true;

    public Laser.LaserColor laserColor;

    public bool powered = false;

    // Use this for initialization
    void Start () {
        // Make a new lasers array of size == dispersalCount
        lasers = new Laser[dispersalCount];

        // Loop through the lasers array and assign a new Laser component to each index
        for (int i = 0; i < lasers.Length; i++)
        {
            lasers[i] = gameObject.AddComponent<Laser>();
        }

        // Then add the LineManager component and store a reference to it as lineManager
        lineManager = gameObject.AddComponent<LineManager>();

        if (colorSplit)
        {
            lasers[0].laserColor = Laser.LaserColor.Red;
            lasers[1].laserColor = Laser.LaserColor.Green;
            lasers[2].laserColor = Laser.LaserColor.Blue;

            lasers[0].laserDirection = Laser.LaserDirection.Right;
            lasers[1].laserDirection = Laser.LaserDirection.Up;
            lasers[2].laserDirection = Laser.LaserDirection.Left;
        }
        else
        {
            lasers[0].laserColor = laserColor;
            lasers[1].laserColor = laserColor;
            lasers[2].laserColor = laserColor;

            lasers[0].laserDirection = Laser.LaserDirection.Right;
            lasers[1].laserDirection = Laser.LaserDirection.Up;
            lasers[2].laserDirection = Laser.LaserDirection.Left;
        }
    }
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < lasers.Length; i++)
        {
            lasers[i].enabled = powered;
            UpdateLaser(lasers[i]);
            lineManager.lines[i].enabled = powered;
        }
    }

    void UpdateLaser(Laser laser)
    {
        if (!colorSplit)
        {
            laser.laserColor = laserColor;
        }
        else if (colorSplit)
        {
            lasers[0].laserColor = Laser.LaserColor.Red;
            lasers[1].laserColor = Laser.LaserColor.Green;
            lasers[2].laserColor = Laser.LaserColor.Blue;
        }
    }
}
