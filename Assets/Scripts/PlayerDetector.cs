using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour {

    [Tooltip("If this component will reflect on persistent interaction.")]
    public bool cannotTouch;
    [Tooltip("The clive supposed to be interacted with. ")]
    public GameObject clive;

    int colliderNum = 0;

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // When it is the first time the body is detected, the cannotTouch function is on and the clive is activated
            if ((colliderNum == 0) && cannotTouch && clive.GetComponent<Clive>().cliveActive)
            {
                // Change the bool values in clive to deactivate it
                clive.GetComponent<Clive>().cliveActive = false;
                clive.GetComponent<Clive>().cliveActiveChanged = true;

                Debug.Log("Player detected! Clive deactivated!");
            }

            colliderNum++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            colliderNum--;
        }
    }
}
