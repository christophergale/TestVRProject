using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activatable : MonoBehaviour {

    [SerializeField]
    public bool activated;

    [SerializeField]
    public ActivatableTarget target;

    public virtual void Update()
    {
        if (activated)
        {
            target.Invoke("ExecuteOnActivate", 0.1f);
            Debug.Log("Activated!");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(this.transform.position, target.transform.position);
        Gizmos.DrawSphere(target.transform.position, 0.1f);
    }
}
