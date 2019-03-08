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

    [HideInInspector]
    public bool chosenCloneable;

    public CliveType cliveType;

    [HideInInspector]
    public CliveType chosenCliveType;

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

        chosenCloneable = cloneable;
        UpdateCloneable();
    }

    private void Update()
    {
        if (chosenCliveType != cliveType)
        {
            chosenCliveType = cliveType;
            UpdateCliveType(chosenCliveType);
        }

        if (chosenCloneable != cloneable)
        {
            chosenCloneable = cloneable;
            UpdateCloneable();
        }
    }

    public void UpdateCliveType(CliveType updatedCliveType)
    {
        //if (GetComponent<CliveClass>())
        //{
        //    if (GetComponent<Tetris>())
        //    {
        //        GetComponent<Tetris>().DestroyShape();
        //    }

        //    Destroy(GetComponent<CliveClass>());
        //}

        CliveClass[] cliveClasses = GetComponents<CliveClass>();
        for (int i = 0; i < cliveClasses.Length; i++)
        {
            if (cliveClasses[i] != GetComponent<Clone>())
            {
                if (cliveClasses[i] == GetComponent<Tetris>())
                {
                    GetComponent<Tetris>().DestroyShape();
                }

                Destroy(cliveClasses[i]);
            }
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
    }

    public void UpdateCloneable()
    {
        if (cloneable && !GetComponent<Clone>())
        {
            Clone clone = gameObject.AddComponent<Clone>();
        }
        else if (!cloneable)
        {
            if (GetComponent<Clone>())
            {
                Destroy(GetComponent<Clone>());
            }
        }
    }
}
