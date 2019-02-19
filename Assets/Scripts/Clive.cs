using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clive : MonoBehaviour {

    public enum CliveType {
        Weight,
        Refractor,
        Reflector,
        Tetris,
        Clone,
        Battery
    }

    public CliveType cliveType;

    CliveType chosenCliveType;

    // [HideInInspector]
    public GameObject cliveCopy;

    private void Start()
    {
        chosenCliveType = cliveType;
        UpdateCliveType(chosenCliveType);
    }

    private void Update()
    {
        if (chosenCliveType != cliveType)
        {
            chosenCliveType = cliveType;
            UpdateCliveType(chosenCliveType);
        }
    }

    public void UpdateCliveType(CliveType updatedCliveType)
    {
        if (GetComponent<CliveClass>())
        {
            if (GetComponent<Tetris>())
            {
                GetComponent<Tetris>().DestroyShape();
            }

            Destroy(GetComponent<CliveClass>());
        }

        if (updatedCliveType == CliveType.Tetris)
        {
            Tetris tetris = gameObject.AddComponent<Tetris>();
        }

        if (updatedCliveType == CliveType.Battery)
        {
            Battery battery = gameObject.AddComponent<Battery>();
        }

        if (updatedCliveType == CliveType.Reflector)
        {
            Reflector reflector = gameObject.AddComponent<Reflector>();
        }

        if (updatedCliveType == CliveType.Clone)
        {
            Clone clone = gameObject.AddComponent<Clone>();
        }

        if (updatedCliveType == CliveType.Weight)
        {
            Weight weight = gameObject.AddComponent<Weight>();
        }
    }
}
