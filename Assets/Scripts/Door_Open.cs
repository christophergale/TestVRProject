using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Open : MonoBehaviour {

    public float openSpeed = 1f;
     //public float rotateSize = 50f;
     //public float runSpeed = 5f;
     //public int requiredKeys = 2;
     //public int recievedKeys;
     //public GameObject dor;
    void Start()
      {
         
        //  if (Input.GetKeyDown(KeyCode.Space))
          //{
           //   //transform.Rotate(Vector3.up * -rotateSize * Time.deltaTime);
           //   Debug.Log("a");  
//}
      
      }
     
    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            //transform.Rotate(Vector3.up * -rotateSize * Time.deltaTime);
            transform.position += Vector3.up * openSpeed * Time.deltaTime;
            Debug.Log("Doors opening!");  
        }
	}

    //public void DoorOpen()
    //{
    //    recievedKeys++;
    //    if (recievedKeys >= requiredKeys)
    //        transform.Rotate(Vector3.up * -rotateSize * Time.deltaTime);
    //}
}

