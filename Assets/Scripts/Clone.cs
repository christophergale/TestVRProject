using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : CliveClass {

    Clive clive;

    GameObject clonePiece;
    public GameObject[] clones;

    public int cloneMaximum;
    private int cloneCurrent = 0;

    private Vector3 scale;

	// Use this for initialization
	void Start () {
        cloneMaximum = Clive.instance.maximumClones;
        clones = new GameObject[cloneMaximum];

        scale = Clive.instance.transform.lossyScale;

        clonePiece = Clive.instance.cliveCopy;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("G key pressed");
            CloneClive();
        }
	}

    public void CloneClive()
    {
        Debug.Log("Cloning Clive!");
        if (cloneCurrent < cloneMaximum)
        {
            if (clones[cloneCurrent] != null)
            {
                DestroyClone(clones[cloneCurrent]);
            }

            clones[cloneCurrent] = Instantiate(clonePiece, this.transform.position, this.transform.rotation);
            clones[cloneCurrent].transform.localScale = scale;
            clones[cloneCurrent].AddComponent<ClonedCube>();

            CliveClass[] cliveClasses = GetComponents<CliveClass>();

            for (int i = 0; i < cliveClasses.Length; i++)
            {
                if (cliveClasses[i] != GetComponent<Clone>())
                {   
                    System.Type myType = cliveClasses[i].GetType();
                    clones[cloneCurrent].AddComponent(myType);
                }
            }

            cloneCurrent += 1;
        }
        else
        {
            cloneCurrent = 0;
        }
    }

    void DestroyClone(GameObject clone)
    {
        if (GetComponentInChildren<LineRenderer>())
        {
            foreach (LineRenderer line in GetComponentsInChildren<LineRenderer>())
            {
                Destroy(line.gameObject);
            }
        }

        Destroy(clone);
    }
}
