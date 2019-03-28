using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clive : MonoBehaviour {

    // Here we define an enum of different Clive types
    public enum CliveType {
        Combiner,
        Reflector,
        Disperser,
        Tetris,
        Battery
    }

    // The starting CliveType is selected in the Unity Editor
    [Tooltip("Select the starting CliveType here.")]
    public CliveType cliveType;

    // This second chosenCliveType is used to check if the cliveType has been changed during runtime
    [HideInInspector]
    public CliveType chosenCliveType;

    #region Clive Editor
    // Clive Editor:
    [HideInInspector]
    public bool disperserColorSplit;

    [HideInInspector]
    public Tetris.TetrisShape tetrisShape;

    [HideInInspector]
    public int maximumClones;
    #endregion

    // Will the Clive be cloneable at the start of the level? This is set in the Editor
    [Tooltip("Select the starting cloneable here. Will this Clive be cloneable at the start of the level?")]
    public bool cloneable;

    [Space(10)]

    // Again, this second chosenCloneable is used to check if the cloneable has been changed during runtime
    [HideInInspector]
    public bool chosenCloneable;

    // This is the prefab used when constructing Tetris shapes or instantiating clones
    //[HideInInspector]
    public GameObject cliveCopy;

    // This bool is used when deactivating the Clive using a deactivator
    [HideInInspector]
    public bool cliveActive = true;

    // This second bool is used to check if cliveActive has changed during runtime
    [HideInInspector]
    public bool cliveActiveChanged = false;

    [Space(10)]

    // Here we define the MeshRenderer (which will be the MeshRenderer of the child mesh object)
    // We also define the default activeMaterial for when the Clive is active and the deactiveMaterial for when it is not
    public MeshRenderer meshRenderer;
    public Material activeMaterial;
    public Material deactiveMaterial;

    // We need to define the LineRenderer Default-Line material before runtime so that when a Combiner script adds a LineRenderer component to an object, it has a reference to the Default-Line material
    public Material laserMaterial;

    /// <summary>
    /// This sets how often to make Update checks. Set this value to 1 to check every frame, 2 for every other frame and so on.
    /// </summary>
    [Tooltip("This sets how often to make Update checks. Set this value to 1 to check every frame, 2 for every other frame and so on.")]
    public int frameInterval = 1;

    // There will only ever be one Clive, so it can be a Singleton
    public static Clive instance = null;

    private void Awake()
    {
        // Set this as our instance and ensure that there is only ever a single Clive class in the scene
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }

        // We first set our chosenCliveType to be the same as the starting cliveType as set in the Editor
        // And then we UpdateCliveType, passing in the chosenCliveType
        chosenCliveType = cliveType;
        UpdateCliveType(chosenCliveType);

        // Set the chosenCloneable to be the same as the starting cloneable as set in the Editor
        // And call UpdateCloneable
        chosenCloneable = cloneable;
        UpdateCloneable();
    }

    private void Update()
    {
        // We make all of our checks according to the frameInterval
        // This is done for efficiency as we do not need to check every single frame and can instead check every other frame (or another custom interval)
        if (Time.frameCount % frameInterval == 0)
        {
            // Every frame, we check if the chosenCliveType and cliveType are the same, if they are not, then the cliveType has been changed by a CliveChanger
            // In which case, we update chosenCliveType and call UpdateCliveType again
            if (chosenCliveType != cliveType)
            {
                chosenCliveType = cliveType;
                UpdateCliveType(chosenCliveType);
            }

            // The same goes for cloneable...
            if (chosenCloneable != cloneable)
            {
                chosenCloneable = cloneable;
                UpdateCloneable();
            }

            // Every frame, we check call CheckCliveActive
            CheckCliveActive();
        }
    }

    public void UpdateCliveType(CliveType updatedCliveType)
    {
        // Before updating the CliveType, we need to remove all CliveClass components that may be attached to the Clive already
        // We make an array of components that derive from CliveClass
        CliveClass[] cliveClasses = GetComponents<CliveClass>();

        // We then loop through this array
        for (int i = 0; i < cliveClasses.Length; i++)
        {
            // If the CliveClass is not a Clone
            if (cliveClasses[i] != GetComponent<Clone>())
            {
                // If the CliveClass is a Tetris
                if (cliveClasses[i] == GetComponent<Tetris>())
                {
                    // Call DestroyShape to destroy any instantiated Tetris pieces
                    GetComponent<Tetris>().DestroyShape();
                }

                // If the CliveClass is a Combiner
                if (cliveClasses[i] == GetComponent<Combiner>())
                {
                    // Destroy the LineRenderer component
                    Destroy(gameObject.GetComponent<LineRenderer>());
                    // Destroy the Laser component
                    Destroy(gameObject.GetComponent<Laser>());
                }

                if (cliveClasses[i] == GetComponent<Disperser>())
                {
                    // Destroy the LineRenderer component
                    foreach(LineRenderer line in gameObject.GetComponents<LineRenderer>())
                    {
                        Destroy(line);
                    }

                    foreach (Laser laser in gameObject.GetComponents<Laser>())
                    {
                        Destroy(laser);
                    }
                }

                // Then destroy any CliveClasses that are not of type Clone
                Destroy(cliveClasses[i]);
            }
        }

        // When the existing CliveClass components have been destroyed, we add the appropriate CliveClass components based on the chosenCliveType
        if (updatedCliveType == CliveType.Tetris)
        {
            Tetris tetris = gameObject.AddComponent<Tetris>();

            // If the Clive is becoming a Tetris during this UpdateCliveType, we check if there is a TetrisColliderActivatable in the scene
            if (FindObjectOfType<TetrisColliderActivatable>())
            {
                // And call its FindTetrisToCheck to set this Clive as the tetrisToCheck
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

        if (updatedCliveType == CliveType.Combiner)
        {
            Combiner combiner = gameObject.AddComponent<Combiner>();
        }

        if (updatedCliveType == CliveType.Disperser)
        {
            Disperser disperser = gameObject.AddComponent<Disperser>();
        }
    }

    public void UpdateCloneable()
    {
        // If the Clive is cloneable and there is no Clone component already attached
        if (cloneable && !GetComponent<Clone>())
        {
            // Add a Clone component to the Clive
            Clone clone = gameObject.AddComponent<Clone>();
        }
        // If the Clive is not cloneable
        else if (!cloneable)
        {
            // Check if there is already a Clone component attached
            if (GetComponent<Clone>())
            {
                // If so, destroy it
                Destroy(GetComponent<Clone>());
            }
        }
    }

    public void CheckCliveActive()
    {
        // If cliveActive is false and the cliveActiveChanged is true
        // These bools are changed by the DeactivateClive function in the CliveDeactivator
        if (!cliveActive && cliveActiveChanged)
        {
            // We create an array of all the components attached to this Clive that inherit from CliveClass
            CliveClass[] cliveClasses = GetComponents<CliveClass>();
            // We loop through them
            for (int i = 0; i < cliveClasses.Length; i++)
            {
                // We check if the current CliveClass is a Tetris
                if (cliveClasses[i] == GetComponent<Tetris>())
                {
                    // If so we Destroy its shape
                    cliveClasses[i].GetComponent<Tetris>().DestroyShape();
                }

                // And finally Destroy the current CliveClass
                Destroy(cliveClasses[i]);
            }

            // In order to show that the Clive has been deactivated, we change its material accordingly
            meshRenderer.material = deactiveMaterial;

            // Finally we set cliveActiveChanged to false so that this function doesn't run again until it is set to true by CliveDeactivator.DeactivateClive()
            cliveActiveChanged = false;
        }
        // If the cliveActive has been reset to true and cliveActiveChanged
        // These are set accordingly by the CliveReset.ResetClive() function
        else if (cliveActive && cliveActiveChanged)
        {
            // We reset the material to the default activeMaterial
            meshRenderer.material = activeMaterial;

            // And again set cliveActiveChanged to false so that this function doesn't run again until it is set to true
            cliveActiveChanged = false;
        }
    }
}
