using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSound : MonoBehaviour {

    /*public void PlayMusicByName(string Name)
    {
        AudioClip clip = Resources.Load<AudioClip>("Sounds/" + name);
        AudioSource.PlayClipAtPoint(clip, gameObject.transform.position);
    }
    */
    public AudioClip saw;
    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = saw;
            
            }

    void OnTriggerEnter()
    {
        GetComponent<AudioSource>().Play();
    }
}
