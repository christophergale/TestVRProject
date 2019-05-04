using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnActivate : ActivatableTarget {

    public Vector3 startPosition;
    public Vector3 moveToPosition;

    /// <summary>
    /// The time taken to move from the start to finish positions
    /// </summary>
    public float lerpTime = 5f;

    //The Time.time value when we started the interpolation
    private float beginLerp;

    private void Start()
    {
        startPosition = transform.position;
    }

    public override void ExecuteOnActivate()
    {
        base.ExecuteOnActivate();

        Debug.Log("Moving!");

        beginLerp = Time.time;
    }

    public void FixedUpdate()
    {
        if (activated)
        {
            float timeSinceStarted = Time.time - beginLerp;
            float percentageComplete = timeSinceStarted / lerpTime;

            transform.position = Vector3.Lerp(startPosition, moveToPosition, percentageComplete);
        }
    }
}
