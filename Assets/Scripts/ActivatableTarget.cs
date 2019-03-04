using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatableTarget : MonoBehaviour {

    public virtual void ExecuteOnActivate()
    {
        Debug.Log("ExecuteOnActivate!");
    }

}
