using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyClones : ActivatableTarget {

    [Tooltip("Will the Clive need to come into contact with this component in order to change the Clive? Or will it be triggered by something else in the level?")]
    public bool isTriggerDestroyClone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Clive") && isTriggerDestroyClone)
        {
            ExecuteOnActivate();
        }
    }

    public override void ExecuteOnActivate()
    {
        base.ExecuteOnActivate();

        for (int i = 0;  i < Clive.instance.GetComponent<Clone>().clones.Length; i++)
        {
            if (Clive.instance.GetComponent<Clone>().clones[i] != null)
            {
                Destroy(Clive.instance.GetComponent<Clone>().clones[i].gameObject);
                Clive.instance.GetComponent<Clone>().clones[i] = null;
            }
        }
    }
}
