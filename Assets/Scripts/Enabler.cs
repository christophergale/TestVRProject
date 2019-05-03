using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enabler : ActivatableTarget {

    public GameObject target;

	// Use this for initialization
	void Start () {
		
	}

    public override void ExecuteOnActivate()
    {
        base.ExecuteOnActivate();
        target.SetActive(true);
    }
}
