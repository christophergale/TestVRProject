using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClonedCube : MonoBehaviour {

    public float timer;

	// Use this for initialization
	void Start () {
        if (Clive.instance.cloneTimer > 0.0f)
        {
            timer = Clive.instance.cloneTimer;
        }
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;

        if (Clive.instance.cloneTimer > 0.0f && timer <= 0.0f)
        {
            Destroy(this.gameObject);
        }
	}

    public void ResetTimer()
    {
        timer = Clive.instance.cloneTimer;
    }
}
