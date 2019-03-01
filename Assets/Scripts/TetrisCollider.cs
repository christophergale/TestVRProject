using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisCollider : Activatable {

    public float tolerance = 0.1f;
    public Material defaultMaterial;
    public Material activatedMaterial;

    public Tetris tetrisCollider;
    public Tetris tetrisToCheck;

    bool completed = false;

	// Use this for initialization
	void Start () {
        defaultMaterial = GetComponent<MeshRenderer>().material;
        tetrisCollider = GetComponent<Tetris>();
        tetrisToCheck = Clive.instance.GetComponent<Tetris>();
	}
	
	// Update is called once per frame
	void Update () {
        CheckAlignment();

        if (!activated)
        {
            activated = CheckCompletion();
        }
    }

    void CheckAlignment()
    {
        for (int i = 0; i < tetrisToCheck.tetrisPieces.Length; i++)
        {
            if (Vector3.Magnitude(tetrisToCheck.tetrisPieces[i].transform.position - tetrisCollider.tetrisPieces[i].transform.position) < tolerance)
            {
                tetrisCollider.tetrisPieces[i].GetComponent<MeshRenderer>().material = activatedMaterial;
                tetrisCollider.tetrisPieces[i].GetComponent<Activatable>().activated = true;
            }
            else
            {
                tetrisCollider.tetrisPieces[i].GetComponent<MeshRenderer>().material = defaultMaterial;
                tetrisCollider.tetrisPieces[i].GetComponent<Activatable>().activated = false;
            }
        }
    }

    bool CheckCompletion()
    {
        bool completedCheck = false;

        for (int i = 0; i < tetrisToCheck.tetrisPieces.Length; i++)
        {
            if (tetrisCollider.tetrisPieces[i].GetComponent<Activatable>().activated)
            {
                completedCheck = true;
            }
            else
            {
                completedCheck = false;
                break;
            }
        }

        return completedCheck;
    }
}
