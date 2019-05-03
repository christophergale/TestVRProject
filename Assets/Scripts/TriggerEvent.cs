using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    public string[] tagFilter;
    public UnityEvent onTriggering;

    private void OnTriggerEnter(Collider other)
    {
        if (tagFilter == null || tagFilter.Length <= 0)
        {
            onTriggering.Invoke();
            return;
        }

        foreach (var tag in tagFilter)
        {
            if (tag == other.tag)
            {
                onTriggering.Invoke();
            }
        }
    }
}
