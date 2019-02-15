using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weight : CliveClass {

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.GetComponent<Switch>().switchType == Switch.SwitchType.Weight)
        {
            collision.gameObject.GetComponent<Switch>().activated = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<Switch>().switchType == Switch.SwitchType.Weight)
        {
            collision.gameObject.GetComponent<Switch>().activated = false;
        }
    }
}
