using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCube2 : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
