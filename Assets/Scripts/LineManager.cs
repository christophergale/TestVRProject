using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour {

    [HideInInspector]
    public List<LineRenderer> lines;

	// Use this for initialization
	void Start () {
        // When the LineManager is enabled, we check if there are already any Laser components attached to this gameObject
        // If there is, we call ConstructLines()
        if (GetComponent<Laser>())
        {
            ConstructLines();
        }
    }

    public void ConstructLines()
    {
        // Make a new lasers array of Laser components attached to this gameObject
        // Disperser should have added 3 Laser components before this function is called
        Laser[] lasers = new Laser[GetComponents<Laser>().Length];

        lasers = GetComponents<Laser>();

        lines = new List<LineRenderer>();

        for (int i = 0; i < lasers.Length; i++)
        {
            lines.Add(new GameObject().AddComponent<LineRenderer>());
        }

        foreach (LineRenderer line in lines)
        {
            line.gameObject.transform.parent = this.gameObject.transform;
            line.material = Clive.instance.laserMaterial;
            line.startWidth = line.endWidth = 0.03f;
        }

        for (int i = 0; i < lasers.Length; i++)
        {
            lasers[i].line = lines[i];
        }
    }
}
