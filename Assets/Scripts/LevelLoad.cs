using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour {
    [SerializeField]
    private string loadLevel;
    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Clive")
        {
            SceneManager.LoadScene(loadLevel);
            Debug.Log("aaaaa");
        }
    }


}
