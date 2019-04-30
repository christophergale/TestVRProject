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
            return new Color(1.0f, 1.0f, 1.0f, 0.7f);

        if (chosenLaserRequired == Laser.LaserColor.Red)
            return new Color(1.0f, 0f, 0f, 0.7f);

        if (chosenLaserRequired == Laser.LaserColor.Green)
            return new Color(0f, 1.0f, 0f, 0.7f);

        if (chosenLaserRequired == Laser.LaserColor.Blue)
            return new Color(0f, 0f, 1.0f, 0.7f);

        if (chosenLaserRequired == Laser.LaserColor.Yellow)
            return new Color(1.0f, 1.0f, 0f, 0.7f);

        if (chosenLaserRequired == Laser.LaserColor.Magenta)
            return new Color(1.0f, 0f, 1.0f, 0.7f);

        if (chosenLaserRequired == Laser.LaserColor.Cyan)
            return new Color(0f, 1.0f, 1.0f, 0.7f);

        return Color.white;
    }
}
