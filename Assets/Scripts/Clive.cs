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

    public bool cliveActive = true;
    [HideInInspector]
    public bool cliveActiveChanged = false;
    public MeshRenderer meshRenderer;
    public Material activeMaterial;
    public Material deactiveMaterial;

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

        CheckCliveActive();
    }

    public void UpdateCliveType(CliveType updatedCliveType)
    {
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

            if (FindObjectOfType<TetrisColliderActivatable>())
            {
                FindObjectOfType<TetrisColliderActivatable>().FindTetrisToCheck();
            }
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

    public void CheckCliveActive()
    {
        if (!cliveActive && cliveActiveChanged)
        {
            CliveClass[] cliveClasses = GetComponents<CliveClass>();
            for (int i = 0; i < cliveClasses.Length; i++)
            {
                if (cliveClasses[i] == GetComponent<Tetris>())
                {
                    cliveClasses[i].GetComponent<Tetris>().DestroyShape();
                }

                Destroy(cliveClasses[i]);
            }

            meshRenderer.material = deactiveMaterial;

            cliveActiveChanged = false;
        }
        else if (cliveActive && cliveActiveChanged)
        {
            meshRenderer.material = activeMaterial;

            cliveActiveChanged = false;
        }
    }
}
