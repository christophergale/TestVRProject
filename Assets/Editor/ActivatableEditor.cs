using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Activatable))]
public class ActivatableEditor : Editor {

    private void OnSceneGUI()
    {
        Activatable activatable = target as Activatable;
        if (activatable == null)
            return;

        Handles.color = Color.red;

        // Handles.FreeMoveHandle(activatable.target.transform.position, Quaternion.identity, 0.3f, Vector2.zero, Handles.CircleHandleCap);
        Handles.CircleCap(0, activatable.target.transform.position, Quaternion.identity, 0.3f);
    }
}
