using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticClone : MonoBehaviour {

    public float waitingTime = 5f;

    bool checking = false;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (!checking)
        {
            StartCoroutine("CheckPosition");
        }
	}

    IEnumerator CheckPosition()
    {
        checking = true;

        Debug.Log("Checking Position!");
        Vector3 position = transform.position;

        float tolerance = 0.3f;

        yield return new WaitForSeconds(waitingTime);

        if (position.sqrMagnitude >= tolerance * tolerance)
        {
            GetComponent<Clone>().CloneClive();
        }

        checking = false;
    }
}
