using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatableTarget : MonoBehaviour {

    // All game elements that will have their behaviour changed by an Activatable will inhereit from this class
    // This includes doors, lights and even other Activatables that may be triggered by the target
    // For example, the player may activate a weight switch, which then enables a laser and a laser switch in the scene
    // This parent ActivatableTarget has only one virtual function: ExecuteOnActivate
    // Individual targets will have different behaviour (e.g. a light turning on) that will be defined in their respective override ExecuteOnActivate functions

    [HideInInspector]
    public bool activated;

    bool hasBeenActivated = false;

    public virtual void Update()
    {
        if (activated && !hasBeenActivated)
        {
            ExecuteOnActivate();
            hasBeenActivated = true;
        }

        if (!activated && hasBeenActivated)
        {
            ExecuteOnDeactivate();
            hasBeenActivated = false;
        }
    }

    public virtual void ExecuteOnActivate()
    {
        Debug.Log(this.gameObject.name + " ExecuteOnActivate!");
    }

    public virtual void ExecuteOnDeactivate()
    {
        Debug.Log(this.gameObject.name + " ExecuteOnDeactivate!");
    }
}