using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightSwitchActivatable : Activatable {

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Clive"))
        {
            activated = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Clive"))
        {
            activated = false;
        }
    }
}
