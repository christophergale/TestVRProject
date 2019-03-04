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
            target.Invoke("ExecuteOnActivate", 0.1f);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(this.transform.position, target.transform.position);
    }
}
