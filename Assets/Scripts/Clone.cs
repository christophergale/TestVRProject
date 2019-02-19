using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : CliveClass {

    GameObject clonePiece;
    public GameObject[] clones;

    public int cloneMaximum = 3;
    private int cloneCurrent = 0;

	// Use this for initialization
	void Start () {
        clonePiece = GetComponent<Clive>().cliveCopy;
        clones = new GameObject[cloneMaximum];
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("G key pressed");
            CloneClive();
        }
	}

    void CloneClive()
    {
        if (cloneCurrent < cloneMaximum)
        {
            if (clones[cloneCurrent] != null)
            {
                Destroy(clones[cloneCurrent]);
            }

            clones[cloneCurrent] = Instantiate(clonePiece, this.transform.position, this.transform.rotation);
            cloneCurrent += 1;
        }
        else
        {
            cloneCurrent = 0;
        }
        
    }
}
