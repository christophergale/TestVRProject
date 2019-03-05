using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activatable : MonoBehaviour {

    // All game elements that the player can interact with to "activate" them will inherit from this class
    // This includes switches (weight, tetris collider, laser etc.)

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
