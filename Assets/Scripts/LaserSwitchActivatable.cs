using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSwitchActivatable : Activatable {

    public bool colorSpecific;
    public Laser.LaserColor laserRequired;

    public override void Update()
    {
        base.Update();
    }
}
