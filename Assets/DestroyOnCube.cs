using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCube : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
