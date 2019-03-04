using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activatable : MonoBehaviour {

    [SerializeField]
    public bool activated;

    bool invoked = false;

    [SerializeField]
    public ActivatableTarget target;

    public virtual void Update()
    {
        if (activated && !invoked)
        {
            target.ExecuteOnActivate();
            invoked = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(this.transform.position, target.transform.position);
        Gizmos.DrawSphere(target.transform.position, 0.1f);
    }
}
