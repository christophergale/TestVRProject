using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSwitchActivatable : Activatable {

    public bool colorSpecific;
    public Laser.LaserColor laserRequired;
    Laser.LaserColor chosenLaserRequired;

    Material material;

    private void Start()
    {
        material = GetComponent<MeshRenderer>().material;

        if (colorSpecific)
        {
            chosenLaserRequired = laserRequired;
            material.color = CheckSwitchColor();
        }
    }

    public override void Update()
    {
        base.Update();

        if (colorSpecific)
        {
            if (chosenLaserRequired != laserRequired)
            {
                chosenLaserRequired = laserRequired;
                material.color = CheckSwitchColor();
            }
        }
    }

    Color CheckSwitchColor()
    {
        if (chosenLaserRequired == Laser.LaserColor.White)
            return Color.white;

        if (chosenLaserRequired == Laser.LaserColor.Red)
            return Color.red;

        if (chosenLaserRequired == Laser.LaserColor.Green)
            return Color.green;

        if (chosenLaserRequired == Laser.LaserColor.Blue)
            return Color.blue;

        if (chosenLaserRequired == Laser.LaserColor.Yellow)
            return Color.yellow;

        if (chosenLaserRequired == Laser.LaserColor.Magenta)
            return Color.magenta;

        if (chosenLaserRequired == Laser.LaserColor.Cyan)
            return Color.cyan;

        return Color.white;
    }
}
