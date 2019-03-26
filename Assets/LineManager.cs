using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour {

    [HideInInspector]
    public Laser[] lasers;

    [HideInInspector]
    public List<LineRenderer> lines;

	// Use this for initialization
	void Start () {
        if (GetComponent<Laser>())
        {
            ConstructLines();
        }
    }

    public void ConstructLines()
    {
        lasers = GetComponents<Laser>();

        lines.Clear();

        foreach (Laser laser in lasers)
        {
            lines.Add(new GameObject().AddComponent<LineRenderer>());
        }

        foreach (LineRenderer line in lines)
        {
            line.material = Clive.instance.laserMaterial;
            line.startWidth = line.endWidth = 0.03f;
        }

        for (int i = 0; i < lasers.Length; i++)
        {
            lasers[i].line = lines[i];
        }
    }
}
