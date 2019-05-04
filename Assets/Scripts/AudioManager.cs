using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioSource[] laserAudioSources;
    public Laser laser;
    float t = 0.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        for (int i = 0; i < laserAudioSources.Length; i++)
        {
            laserAudioSources[i].volume = 0.0f;
        }

        if (laser.reflections > 0)
        {
            for (int i = 1; i <= laser.reflections; i++)
            {
                laserAudioSources[i - 1].volume = 1.0f;
            }
        }
	}
}
