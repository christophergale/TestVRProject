using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LaserGuideActivatable))]
public class LaserGuideInspector : Editor {

    private void OnSceneGUI()
    {
        LaserGuideActivatable laserGuide = target as LaserGuideActivatable;

        if (laserGuide == null)
            return;

        Handles.color = Color.white;

        for (int i = 0; i < laserGuide.points.Length; i++)
        {
            Vector3 newPos = Handles.FreeMoveHandle(laserGuide.points[i], Quaternion.identity, 0.2f, Vector3.zero, Handles.SphereHandleCap);
            //Vector3 newPos = Handles.PositionHandle(laserGuide.points[i], Quaternion.identity);
            Handles.Label(laserGuide.points[i], i.ToString());

            if (laserGuide.points[i] != newPos)
            {
                Undo.RecordObject(laserGuide, "Move point");
                laserGuide.points[i] = newPos;
                laserGuide.UpdateLine();
            }
        }
    }
}
