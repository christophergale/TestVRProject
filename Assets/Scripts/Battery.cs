using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : CliveClass
{

    public float power = 50.0f;
    public float powerDrain = 5.0f;

    public bool onSwitch;
    public bool powering;

    Switch powerSwitch;

    // Update is called once per frame
    void Update()
    {
        if (powering)
        {
            power -= (power * Time.deltaTime);
        }

        if (onSwitch)
        {
            powering = powerSwitch.activated = (power > 0.0f);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.GetComponent<Switch>().switchType == Switch.SwitchType.Battery)
        {
            onSwitch = true;
            powerSwitch = collision.gameObject.GetComponent<Switch>();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<Switch>().switchType == Switch.SwitchType.Battery)
        {
            onSwitch = false;
            powerSwitch = null;
        }
    }
}
