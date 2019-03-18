using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CliveDeactivator : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Clive"))
        {
            Debug.Log("Deactivating Clive!");
            DeactivateClive(other);
        }
    }

    public void DeactivateClive(Collider clive)
    {
        clive.GetComponent<Clive>().cliveActive = false;
        clive.GetComponent<Clive>().cliveActiveChanged = true;
    }
}
