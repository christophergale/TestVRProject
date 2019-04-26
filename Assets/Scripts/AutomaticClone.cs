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

        Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        float tolerance = 0.3f;

        yield return new WaitForSeconds(3.0f);

        if (Mathf.Abs(position.x - transform.position.x) < tolerance && Mathf.Abs(position.y - transform.position.y) < tolerance && Mathf.Abs(position.y - transform.position.y) < tolerance)
        {
            GetComponent<Clone>().CloneClive();
        }

        checking = false;
    }
}
