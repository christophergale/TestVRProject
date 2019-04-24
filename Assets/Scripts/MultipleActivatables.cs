using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleActivatables : Activatable {

    public Activatable[] activatables;

    new void Update()
    {
        if (!isOneWayActivatable)
        {
            foreach (Activatable activatable in activatables)
            {
                if (!activatable.activated)
                {
                    activated = false;
                    break;
                }
                else
                {
                    activated = true;
                }
            }
        }
        else if (isOneWayActivatable && !activated)
        {
            foreach (Activatable activatable in activatables)
            {
                if (!activatable.activated)
                {
                    activated = false;
                    break;
                }
                else
                {
                    activated = true;
                }
            }
        }

        if (activated)
        {
            foreach (ActivatableTarget target in targets)
            {
                target.activated = true;
            }
        }
    }
}
