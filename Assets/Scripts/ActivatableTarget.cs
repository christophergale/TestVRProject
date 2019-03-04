using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatableTarget : MonoBehaviour {

    public bool activated;

    public virtual void ExecuteOnActivate()
    {
        activated = true;
        Debug.Log("ExecuteOnActivate!");
    }

}
