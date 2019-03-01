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

    public bool cloneable;

    public CliveType cliveType;

    CliveType chosenCliveType;

    // [HideInInspector]
    public GameObject cliveCopy;

    public static Clive instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }

        chosenCliveType = cliveType;
        UpdateCliveType(chosenCliveType);
    }

    private void Start()
    {

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

        if (updatedCliveType == CliveType.Weight)
        {
            Weight weight = gameObject.AddComponent<Weight>();
        }

        if (cloneable)
        {
            Clone clone = gameObject.AddComponent<Clone>();
        }
    }
}
