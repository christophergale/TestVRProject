using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    public enum SwitchType {
        Weight,
        Laser,
        Battery
    }

    public Light light;
    public Material on;
    public bool activated;

    public SwitchType switchType;
	
	// Update is called once per frame
    void Update () {
        if (activated)
        {
            GetComponent<MeshRenderer>().material = on;
        }
	}
}
