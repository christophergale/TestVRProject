using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : ActivatableTarget {

    public enum SwitchType
    {
        Weight,
        Laser,
        Battery
    }

    public SwitchType switchType;

    public Material on;
	
	// Update is called once per frame
    public override void ExecuteOnActivate () {
        base.ExecuteOnActivate();
        GetComponent<MeshRenderer>().material = on;
	}
}
