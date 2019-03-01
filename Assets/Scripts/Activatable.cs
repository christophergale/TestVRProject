using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activatable : MonoBehaviour {

    [SerializeField]
    public bool activated;

    [SerializeField]
    public ActivatableTarget target;

    private void Update()
    {
        if (activated)
        {
            target.activated = true;
        }
    }
}
