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

    GameObject[] tetrisPieces;

	// Use this for initialization
	void Start () {
        tetrisPieces = new GameObject[3];
        tetrisPiece = GetComponent<Clive>().cliveCopy;

        for (int i = 0; i < 3; i++)
        {
            tetrisPieces[i] = Instantiate(tetrisPiece, this.transform.position, Quaternion.identity);
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

        if (shape == TetrisShape.T)
        {
            tetrisPieces[0].transform.position = transform.position + Vector3.up / 2;
            tetrisPieces[1].transform.position = transform.position + Vector3.right / 2;
            tetrisPieces[2].transform.position = transform.position - Vector3.right / 2; 
        }

        if (shape == TetrisShape.O)
        {
            tetrisPieces[0].transform.position = transform.position + Vector3.up / 2;
            tetrisPieces[1].transform.position = transform.position + Vector3.right / 2;
            tetrisPieces[2].transform.position = transform.position + Vector3.right + Vector3.up / 2;
        }

        if (shape == TetrisShape.J)
        {
            tetrisPieces[0].transform.position = transform.position + Vector3.up / 2;
            tetrisPieces[1].transform.position = transform.position + Vector3.right / 2;
            tetrisPieces[2].transform.position = transform.position + Vector3.right + Vector3.right / 2;
        }

        for (int i = 0; i < 3; i++)
        {
            tetrisPieces[i].transform.parent = this.transform;
        }
    }
}
