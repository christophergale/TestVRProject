using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CliveController : MonoBehaviour {

    public bool isHolding;
    public bool rotating;
    public Vector3 offset;

    private Clive clive;
    private Rigidbody cliveRB;

    public float rotateSpeed = 5.0f;

    private void Start()
    {
        clive = GetComponent<Clive>();
    }

    private void Update()
    {
        if (rotating)
        {
            clive.transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
        }
                
        if (isHolding)
        {
            float angle = transform.localRotation.y;
            Vector3 viewDirection = new Vector3(Mathf.Cos(angle), 0.0f, Mathf.Sin(angle)).normalized;
            clive.transform.position = transform.position + -viewDirection * 2f;

            cliveRB.isKinematic = true;
            clive.GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("CLIVE") && Input.GetMouseButtonDown(0) && !isHolding)
        {
            isHolding = true;
            clive = other.GetComponent<Clive>();
            cliveRB = clive.GetComponent<Rigidbody>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CLIVE"))
        {
            Debug.Log("Trigger");   
        }
    }
}
