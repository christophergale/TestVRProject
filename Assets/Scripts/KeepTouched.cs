using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepTouched : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Reset the cloneTimer in ClonedCube to keep the copy from being destroyed
            gameObject.GetComponent<ClonedCube>().ResetTimer();
        }
    }
}
