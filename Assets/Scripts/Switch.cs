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
    public Material off;
	
	// Update is called once per frame
    public override void ExecuteOnActivate () {
        base.ExecuteOnActivate();

        if (GetComponent<MeshRenderer>().material == off)
        {
            GetComponent<MeshRenderer>().material = on;
        }
        else if (GetComponent<MeshRenderer>().material == on)
        {
            GetComponent<MeshRenderer>().material = off;
        }
        
	}
}
