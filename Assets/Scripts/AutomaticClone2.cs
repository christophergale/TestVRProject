using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticClone2 : MonoBehaviour
{

    public bool checking = false;
    Vector3 position;
    Vector3 rotation;
    public float timer;

    public float positionTolerance = 30f;
    public float rotationTolerance = 500f;

    private void Start()
    {
        position = transform.position;
        rotation = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (!checking) return;

        position -= transform.position;
        rotation -= transform.eulerAngles;

        if (position.sqrMagnitude < positionTolerance * positionTolerance * Time.deltaTime * Time.deltaTime &&
            rotation.sqrMagnitude < rotationTolerance * rotationTolerance * Time.deltaTime * Time.deltaTime)
            timer += Time.deltaTime;
        else
            timer = 0;
        
        position = transform.position;
        rotation = transform.eulerAngles;

        if (timer >= 3)
        {
            GetComponent<Clone>().CloneClive();
            timer = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "PuzzleTrigger")
            return;

        checking = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "PuzzleTrigger")
            return;
        checking = false;
    }
}
