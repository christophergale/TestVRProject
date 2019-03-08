using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetris : CliveClass {

    // Define the shape enum
    public enum TetrisShape
    {
        O,
        T,
        J
    }

    // tetrisShape is selected in the Editor (or via code)
    /// <summary>
    /// This is the desired tetris shape.
    /// </summary>
    [Tooltip("This is the desired tetris shape.")]
    public TetrisShape tetrisShape;

    // chosenShape is used to check if the tetrisShape that has been selected in the Editor (or via code) has been updated during runtime
    TetrisShape chosenShape;

    // tetrisPiece is the Prefab to be instantiated
    private GameObject tetrisPiece;
    // tetrisPieces is the array that we will populate with these instantiated Prefabs
    public GameObject[] tetrisPieces;

    // scale will be a Vector3 of the lossyScale of the Tetris parent game object and will be used to rescale the child tetrisPieces
    private Vector3 scale;

    // Is this Tetris the player's Clive Tetris or a collider for testing alignment?
    public bool isCollider;

	// Use this for initialization
	void Start () {
        // Get a reference to this object's scale in world space
        scale = this.gameObject.transform.lossyScale;

        // Create a new array of 3 GameObjects
        tetrisPieces = new GameObject[3];
        // Get a reference to the Prefab element assigned to the player's Clive
        tetrisPiece = Clive.instance.cliveCopy;

        // Loop through the tetrisPieces array
        for (int i = 0; i < tetrisPieces.Length; i++)
        {
            // Instantiate the tetrisPiece Prefab at the parent object's position and rotation
            tetrisPieces[i] = Instantiate(tetrisPiece, this.transform.position, this.transform.rotation);
            // Set each of the tetrisPieces scale to match the parent
            tetrisPieces[i].transform.localScale = scale;
        }

        chosenShape = tetrisShape;
        // Call the UpdateShape function, passing in the chosenShape enum
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

        // First, define up, right, down and left positions, based on the current rotation and scale of the parent
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

        // Parent all of the tetrisPieces to the game object this Tetris script is attached to
        for (int i = 0; i < 3; i++)
        {
            tetrisPieces[i].transform.parent = this.transform;
        }

        // If the tetris shape is a collider
        if (isCollider)
        {
            // Loop through the tetrisPieces
            for (int i = 0; i < tetrisPieces.Length; i++)
            {
                // Disable the box collider
                tetrisPieces[i].GetComponent<BoxCollider>().enabled = false;
                // Tag each tetrisPiece accordingly
                tetrisPieces[i].gameObject.tag = "TetrisColliderActivatable";
                // Add an Activatable component to each tetrisPiece
                // tetrisPieces[i].AddComponent<Activatable>();
            }

            if (!GetComponent<TetrisColliderActivatable>())
            {
                // Add the TetrisColliderActivatable component to this parent object
                gameObject.AddComponent<TetrisColliderActivatable>();
            }

            // Disable the box collider
            GetComponent<BoxCollider>().enabled = false;
            // Tag this parent object accordingly
            this.gameObject.tag = "TetrisColliderActivatable";
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
