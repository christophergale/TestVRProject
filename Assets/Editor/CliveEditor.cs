using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Clive))]
public class CliveEditor : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Clive clive = target as Clive;

        if (clive.cloneable)
        {
            clive.maximumClones = EditorGUILayout.IntField("Maximum Clones", clive.maximumClones);
        }

        if (clive.cliveType == Clive.CliveType.Disperser)
        {
            clive.disperserColorSplit = EditorGUILayout.Toggle("Is Color Split?", clive.disperserColorSplit);
        }

        if (clive.cliveType == Clive.CliveType.Tetris)
        {
            clive.tetrisShape = (Tetris.TetrisShape)EditorGUILayout.EnumPopup("Tetris Shape", clive.tetrisShape);
        }
    }
}
