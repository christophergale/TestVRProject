using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisCollider : Activatable {

    // The tolerance will be used when checking the distance between the tetris collider and the tetris to be checked
    public float tolerance = 0.1f;

    // Materials currently being used for testing success
    public Material defaultMaterial;
    public Material activatedMaterial;

    // tetrisCollider will be the Tetris component attached to the game object that this TetrisCollider component is also attached to
    // This is so that we can access the Tetris.tetrisPieces array for our distance check
    public Tetris tetrisCollider;

    // The tetrisToCheck will be the player's Clive 99% of the time
    public Tetris tetrisToCheck;

	// Use this for initialization
	void Start () {
        defaultMaterial = GetComponent<MeshRenderer>().material;
        tetrisCollider = GetComponent<Tetris>();
        tetrisToCheck = Clive.instance.GetComponent<Tetris>();
	}
	
	// Update is called once per frame
	void Update () {
        // Each frame, we call the CheckAlignment function
        activated = CheckAlignment();

        // Each frame, if this TetrisCollider has not be activated yet, we call the CheckCompletion function
        //if (!activated)
        //{
        //    activated = CheckCompletion();
        //}
    }

    bool CheckAlignment()
    {
        // Loop through the tetrisPieces on the tetrisToCheck (probably the player's Clive)
        for (int i = 0; i < tetrisToCheck.tetrisPieces.Length; i++)
        {
            // Check if the magnitude of the vector between the corresponding tetrisPieces is shorter than the tolerance
            if (Vector3.Magnitude(tetrisToCheck.tetrisPieces[i].transform.position - tetrisCollider.tetrisPieces[i].transform.position) < tolerance)
            {
                // If so, change the material so that the player gets some feedback
                tetrisCollider.tetrisPieces[i].GetComponent<MeshRenderer>().material = activatedMaterial;
            }
            else
            {
                // Otherwise, the material should be the default material
                tetrisCollider.tetrisPieces[i].GetComponent<MeshRenderer>().material = defaultMaterial;
            }
        }

        bool completedCheck = false;

        for (int i = 0; i < tetrisToCheck.tetrisPieces.Length; i++)
        {
            // Check if the magnitude of the vector between the corresponding tetrisPieces is shorter than the tolerance
            if (Vector3.Magnitude(tetrisToCheck.tetrisPieces[i].transform.position - tetrisCollider.tetrisPieces[i].transform.position) < tolerance)
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

    //bool CheckCompletion()
    //{
    //    // First we create a bool that is initialised as false
    //    bool completedCheck = false;

    //    // Loop through the tetrisPieces on the tetrisToCheck
    //    for (int i = 0; i < tetrisCollider.tetrisPieces.Length; i++)
    //    {
    //        // This if/else statement checks if the tetrisPiece is activated. If so, it sets completedCheck to true...
    //        // and moves onto the next tetrisPiece
    //        // If all tetrisPieces are activated, we return completedCheck as true
    //        if (tetrisCollider.tetrisPieces[i].GetComponent<Activatable>().activated)
    //        {
    //            completedCheck = true;
    //        }
    //        else
    //        {
    //            // If any of the tetrisPieces are not activated, we set completedCheck to false and break out of the loop...
    //            // So that a false can be returned
    //            completedCheck = false;
    //            break;
    //        }
    //    }

    //    // I.e. this function checks if ALL of the tetrisPieces have been activated
    //    return completedCheck;
    //}
}
