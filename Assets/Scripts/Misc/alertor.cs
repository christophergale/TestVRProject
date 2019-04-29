using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alertor : MonoBehaviour {
    public Transform start;
    public Transform end;
    public float Rtime;
    private float timer=0;
    private bool flag = false;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        if (flag)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                flag = false;
            }
        }
        else
        {
            timer += Time.deltaTime;
            if (timer >= Rtime)
            {
                flag = true;
            }
        }
        transform.position = Vector3.Lerp(start.position, end.position, timer/Rtime);


    }
}
