using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CliveChanger : ActivatableTarget {

    [Tooltip("Will the Clive need to come into contact with this component in order to change the Clive? Or will it be triggered by something else in the level?")]
    public bool isTriggerChanger;
    [Space(10)]
    [Tooltip("If this component will change the type of Clive (i.e. Tetris, Reflector etc.), tick this box.")]
    public bool cliveChanger;
    [Tooltip("If this component will change whether the Clive is cloneable or not, tick this box.")]
    public bool cloneableChanger;
    [Space(10)]
    [Tooltip("Select the desired CliveType here. This will only change the Clive if the above Clive Changer is ticked.")]
    public Clive.CliveType changeCliveType;
    [Tooltip("Select whether the updated Clive will be cloneable or not here. This will only change the Clive if the above Cloneable Changer is ticked.")]
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
