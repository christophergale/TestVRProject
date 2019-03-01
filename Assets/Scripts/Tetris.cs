using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetris : CliveClass {

    public enum TetrisShape
    {
        O,
        T,
        J
    }

    public TetrisShape tetrisShape;

    TetrisShape chosenShape;

    public GameObject tetrisPiece;

    public GameObject[] tetrisPieces;

    private Vector3 scale;

    public bool isCollider;

	// Use this for initialization
	void Start () {
        scale = this.gameObject.transform.lossyScale;

        tetrisPieces = new GameObject[3];
        tetrisPiece = Clive.instance.cliveCopy;

        for (int i = 0; i < 3; i++)
        {
            tetrisPieces[i] = Instantiate(tetrisPiece, this.transform.position, this.transform.rotation);
            tetrisPieces[i].transform.localScale = scale;
        }

        chosenShape = tetrisShape;
        UpdateShape(chosenShape);
	}
	
	// Update is called once per frame
	void Update () {
        if (chosenShape != tetrisShape)
        {
            chosenShape = tetrisShape;
            UpdateShape(chosenShape);
        }
	}

    void UpdateShape(TetrisShape shape)
    {
        Debug.Log("Updating shape!");

        Vector3 up = transform.up * scale.x;
        Vector3 right = transform.right * scale.x;
        Vector3 down = -transform.up * scale.x;
        Vector3 left = -transform.right * scale.x;

        if (shape == TetrisShape.T)
        {
            tetrisPieces[0].transform.position = transform.position + up;
            tetrisPieces[1].transform.position = transform.position + right;
            tetrisPieces[2].transform.position = transform.position + left; 
        }

        if (shape == TetrisShape.O)
        {
            tetrisPieces[0].transform.position = transform.position + up;
            tetrisPieces[1].transform.position = transform.position + right;
            tetrisPieces[2].transform.position = transform.position + right + up;
        }

        if (shape == TetrisShape.J)
        {
            tetrisPieces[0].transform.position = transform.position + up;
            tetrisPieces[1].transform.position = transform.position + right;
            tetrisPieces[2].transform.position = transform.position + right + right;
        }

        for (int i = 0; i < 3; i++)
        {
            tetrisPieces[i].transform.parent = this.transform;
        }

        if (isCollider)
        {
            for (int i = 0; i < tetrisPieces.Length; i++)
            {
                tetrisPieces[i].GetComponent<BoxCollider>().isTrigger = true;
                tetrisPieces[i].gameObject.tag = "TetrisCollider";
                tetrisPieces[i].AddComponent<Activatable>();
            }

            gameObject.AddComponent<TetrisCollider>();
            GetComponent<BoxCollider>().isTrigger = true;
            this.gameObject.tag = "TetrisCollider";
        }
    }

    public void DestroyShape()
    {
        for (int i = 0; i < tetrisPieces.Length; i++)
        {
            Destroy(tetrisPieces[i].gameObject);
        }
    }
}
