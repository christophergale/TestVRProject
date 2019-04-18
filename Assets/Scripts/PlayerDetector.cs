using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour {

    [Tooltip("If this component will reflect on persistent interaction.")]
    public bool isImmediate;
    [Tooltip("If this component will reflect on persistent interaction.")]
    public bool isPersistent;

    int colliderNum = 0;

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            colliderNum++;

            if ((colliderNum == 0) && isImmediate)
            {
                // Do something immediately as the collision happens.
                Debug.Log("Player detected!");
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && isPersistent)
        {
            // Do something while the trigger is being touched continuously.
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
