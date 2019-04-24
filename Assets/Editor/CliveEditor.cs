﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Clive))]
public class CliveEditor : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        serializedObject.Update();
        SerializedProperty cloneable = serializedObject.FindProperty("cloneable");
        SerializedProperty maximumClones = serializedObject.FindProperty("maximumClones");

        int maxClones;

        if (cloneable.boolValue == true)
        {
            maximumClones = EditorGUILayout.IntField("Maximum Clones", maxClones);
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
