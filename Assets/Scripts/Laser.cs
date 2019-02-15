using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    LineRenderer line;
    public float laserLength;

	// Use this for initialization
	void Start () {
        line = GetComponent<LineRenderer>();
	}

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        line.SetPosition(0, ray.origin);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.GetComponent<Reflector>())
            {
                line.positionCount = 3;
                line.SetPosition(1, hit.point);

                Ray reflectedRay = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));
                RaycastHit reflectedRayHit;
                if (Physics.Raycast(reflectedRay, out reflectedRayHit))
                {
                    if (reflectedRayHit.collider.CompareTag("Switch"))
                    {
                        line.SetPosition(2, reflectedRayHit.point);
                        Switch switchHit = reflectedRayHit.collider.GetComponent<Switch>();
                        switchHit.activated = true;
                    }
                }

                line.SetPosition(2, reflectedRay.GetPoint(laserLength));
            }
            else
            {
                line.positionCount = 2;
                line.SetPosition(1, hit.point);
            }

            if (hit.collider.CompareTag("Switch") && hit.collider.GetComponent<Switch>().switchType == Switch.SwitchType.Laser)
            {
                line.positionCount = 2;
                line.SetPosition(1, hit.point);
                Switch switchHit = hit.collider.GetComponent<Switch>();
                switchHit.activated = true;
            }
        }
        else
        {
            line.positionCount = 2;
            line.SetPosition(1, ray.GetPoint(laserLength));
        }
    }
}
