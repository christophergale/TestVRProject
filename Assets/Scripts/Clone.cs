using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : CliveClass {

    GameObject clonePiece;

	// Use this for initialization
	void Start () {
        clonePiece = GetComponent<Clive>().cliveCopy;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.G))
        {
            CloneClive();
        }
	}

    void CloneClive()
    {
        Instantiate(clonePiece, this.transform.position, this.transform.rotation);
    }
}
