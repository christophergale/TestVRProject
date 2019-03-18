using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activatable : MonoBehaviour {

    // All game elements that the player can interact with to "activate" them will inherit from this class
    // This includes switches (weight, tetris collider, laser etc.)

    /// <summary>
    /// This sets how often to make activated checks. Set this value to 1 to check every frame, 2 for every other frame and so on.
    /// </summary>
    [Tooltip("This sets how often to make activated checks. Set this value to 1 to check every frame, 2 for every other frame and so on.")]
    public int frameInterval = 1;

    //[HideInInspector]
    public bool activated;

    [Space(10)]

    // isOneWayActivatable should be set to true if this Activatable can only be activated or deactivated once
    // For example, if a switch must be pressed to open a door, once the switch has been pressed, the door will remain open even if the switch is no longer pressed
    /// <summary>
    /// isOneWayActivatable should be set to true if this Activatable can only be activated or deactivated once.
    /// </summary>
    [Tooltip("isOneWayActivatable should be set to true if this Activatable can only be activated or deactivated once.")]
    public bool isOneWayActivatable;

    [Space(10)]

    // Each Activatable can have multiple targets (as we may require a switch to open multiple doors, for example)
    [SerializeField]
    [Tooltip("Drag ActivatableTargets here to be activated by this Activatable.")]
    public List<ActivatableTarget> targets = new List<ActivatableTarget>();

    public virtual void Update()
    {
        // We make all of our checks according to the frameInterval
        // This is done for efficiency as we do not need to check every single frame and can instead check every other frame (or another custom interval)
        if (Time.frameCount % frameInterval == 0)
        {
            // If this is a oneWayActivatable, we loop through all of the targets and set their activated to true
            // This change remains even if this Activatable's activated becomes false (i.e. door remains open even if switch is no longer pressed)
            if (isOneWayActivatable)
            {
                if (activated)
                {
                    for (int i = 0; i < targets.Count; i++)
                    {
                        targets[i].activated = true;
                    }
                }
            }
            // If this is not a oneWayActivatable, we add in code to loop through the targets and return their activated to false
            // (i.e. door closes again if switch is no longer pressed)
            else
            {
                if (activated)
                {
                    for (int i = 0; i < targets.Count; i++)
                    {
                        targets[i].activated = true;
                    }
                }
                else if (!activated)
                {
                    for (int i = 0; i < targets.Count; i++)
                    {
                        targets[i].activated = false;
                    }
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // When selected in the Editor, we draw Gizmos in green or red, depending on whether activated is true or false
        if (activated)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }

        // We loop through this Activatable's targets and draw a line to each one and a sphere at their position
        for (int i = 0; i < targets.Count; i++)
        {
            if (targets != null)
            {
                Gizmos.DrawLine(this.transform.position, targets[i].transform.position);
                Gizmos.DrawSphere(targets[i].transform.position, 0.1f);
            }
        }
    }

    private void OnDrawGizmos()
    {
        // In the Editor, Activatables will all be represented by a "switch" icon
        Gizmos.DrawIcon(transform.position, "SwitchIcon.png", true);
    }
}