using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {
    public GameObject risingObject;
    public float rising_speed = 2f;
    public float rising_Y_Axis = 5.0f;
    public Vector3 positionRising;

    public Vector3 startingPosition;
    private bool isTrigger = false;

    private void Start()
    {
        startingPosition = risingObject.transform.position;
        positionRising.x = risingObject.transform.position.x;
        positionRising.z = risingObject.transform.position.z;
        positionRising.y = startingPosition.y + rising_Y_Axis;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Clive")
        {
            isTrigger = true;
            // positionRising = risingObject.transform.position;
            // positionRising.y = rising_Y_Axis;

            Debug.Log("Rising!");
        }
    }

    private void FixedUpdate()
    {
        if (isTrigger)
        {
            risingObject.transform.position = Vector3.Lerp(risingObject.transform.position, positionRising, rising_speed * Time.fixedDeltaTime);
        }
    }
}
