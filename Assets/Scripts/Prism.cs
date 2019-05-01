using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prism : CliveClass
{

    public int dispersalCount = 2;
    public Laser[] lasers;
    LineManager lineManager;

    public Laser.LaserColor laserColor;

    public bool powered = false;

    // Use this for initialization
    void Start()
    {
        // Make a new lasers array of size == dispersalCount
        lasers = new Laser[dispersalCount];

        // Loop through the lasers array and assign a new Laser component to each index
        for (int i = 0; i < lasers.Length; i++)
        {
            lasers[i] = gameObject.AddComponent<Laser>();
        }

        // Then add the LineManager component and store a reference to it as lineManager
        lineManager = gameObject.AddComponent<LineManager>();

        foreach (Laser laser in lasers)
        {
            laser.laserColor = laserColor;
        }

        lasers[0].laserDirection = Laser.LaserDirection.Right;
        lasers[1].laserDirection = Laser.LaserDirection.Up;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < lasers.Length; i++)
        {
            lasers[i].enabled = powered;
            UpdateLaser(lasers[i]);
            lineManager.lines[i].enabled = powered;
        }
    }

    public void UpdateLaser(Laser laser)
    {
        laser.laserColor = laserColor;
    }
}
