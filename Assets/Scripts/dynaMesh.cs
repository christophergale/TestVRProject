using UnityEngine;
using System.Collections;

public class dynaMesh : MonoBehaviour
{
    [Tooltip("Put the skinned mesh renderer of this game object here.")]
    public SkinnedMeshRenderer meshRenderer;
    [Tooltip("Create an empty mesh collider of this game object and put it here.")]
    public MeshCollider meshCollider;

    void Start()
    {

    }

    void Update()
    {
        Mesh colliderMesh = new Mesh(); // Memory leak
        meshRenderer.BakeMesh(colliderMesh);
        meshCollider.sharedMesh = colliderMesh;
    }
}
