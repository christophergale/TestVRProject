using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CliveChanger : ActivatableTarget {

    public bool isTriggerChanger;

    public bool cliveChanger;
    public bool cloneableChanger;

    public Clive.CliveType changeCliveType;
    public bool changeCloneable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Clive") && isTriggerChanger)
        {
            ExecuteOnActivate();
        }
    }

    public override void ExecuteOnActivate()
    {
        base.ExecuteOnActivate();

        if (cliveChanger && Clive.instance.chosenCliveType != changeCliveType)
        {
            Clive.instance.cliveType = changeCliveType;
        }

        if (cloneableChanger && Clive.instance.chosenCloneable != changeCloneable)
        {
            Clive.instance.cloneable = changeCloneable;
        }
    }
}
