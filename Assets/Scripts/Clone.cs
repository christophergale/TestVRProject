using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : CliveClass {

    Clive clive;

    GameObject clonePiece;
    public GameObject[] clones;

    public int cloneMaximum = 3;
    private int cloneCurrent = 0;

    private Vector3 scale;

	// Use this for initialization
	void Start () {
        clive = FindObjectOfType<Clive>();

        scale = clive.transform.lossyScale;

        clonePiece = clive.cliveCopy;
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
            clones[cloneCurrent].transform.localScale = scale / 2;

            if (clive.cliveType == Clive.CliveType.Reflector)
            {
                clones[cloneCurrent].gameObject.AddComponent<Reflector>();
            }

            cloneCurrent += 1;
        }
        else
        {
            cloneCurrent = 0;
        }
        
    }
}
