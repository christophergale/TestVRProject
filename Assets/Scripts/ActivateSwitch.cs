using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSwitch : ActivatableTarget {

    public GameObject targetObject;

    public bool changeClive;
    public Clive.CliveType cliveTypeChange;

    private void Awake()
    {
        targetObject.SetActive(false);
    }

    public override void ExecuteOnActivate()
    {
        base.ExecuteOnActivate();

        Debug.Log("ActivateSwitch Execute function being called");

        if (changeClive)
        {
            Clive.instance.cliveType = cliveTypeChange;
        }

        targetObject.SetActive(!targetObject.activeInHierarchy);
    }
}
