using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticClone : MonoBehaviour {

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

        yield return new WaitForSeconds(3.0f);

        if (position.sqrMagnitude >= tolerance * tolerance)
        {
            GetComponent<Clone>().CloneClive();
        }

        checking = false;
    }
}
