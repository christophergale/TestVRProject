using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CliveDeactivator : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Clive"))
        {
            Debug.Log("Deactivating Clive!");
            other.GetComponent<Clive>().cliveActive = false;
            other.GetComponent<Clive>().cliveActiveChanged = true;
        }
    }
}
