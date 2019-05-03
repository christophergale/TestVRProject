using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisChanger : ActivatableTarget {

    public bool isTriggerChanger;

    public Tetris.TetrisShape changeTetrisShape;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Clive") && isTriggerChanger)
        {
            ExecuteOnActivate();
        }
    }

    public override void ExecuteOnActivate()
    {
        base.ExecuteOnActivate();

        if (Clive.instance.GetComponent<Tetris>() && Clive.instance.GetComponent<Tetris>().tetrisShape != changeTetrisShape)
        {
            Clive.instance.GetComponent<Tetris>().tetrisShape = changeTetrisShape;
        }

        if (Clive.instance.tetrisShape != changeTetrisShape)
        {
            Clive.instance.tetrisShape = changeTetrisShape;
        }
    }
}
