using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour {
   
   private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Clive"))
        {
            int sceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(sceneToLoad);
            
       }
    }
}
