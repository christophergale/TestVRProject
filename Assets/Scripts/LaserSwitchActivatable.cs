using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSwitchActivatable : Activatable {

    public bool colorSpecific;
    public Laser.LaserColor laserRequired;

    Material material;

    private void Start()
    {
        material = GetComponent<MeshRenderer>().material;

        if (colorSpecific)
        {
            material.color = CheckSwitchColor();
        }
    }

    public override void Update()
    {
        base.Update();
    }

    Color CheckSwitchColor()
    {
        if (laserRequired == Laser.LaserColor.White)
            return Color.white;

        if (laserRequired == Laser.LaserColor.Red)
            return Color.red;

        if (laserRequired == Laser.LaserColor.Green)
            return Color.green;

        if (laserRequired == Laser.LaserColor.Blue)
            return Color.blue;

        if (laserRequired == Laser.LaserColor.Yellow)
            return Color.yellow;

        if (laserRequired == Laser.LaserColor.Magenta)
            return Color.magenta;

        if (laserRequired == Laser.LaserColor.Cyan)
            return Color.cyan;

        return Color.white;
    }
}
