using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CliveReset : MonoBehaviour {

    private CliveChanger cliveChanger;

	// Use this for initialization
	void Awake () {
        cliveChanger = GetComponent<CliveChanger>();

        cliveChanger.cloneableChanger = true;
        cliveChanger.cliveChanger = true;
	}

    private void Start()
    {
        cliveChanger.changeCliveType = Clive.instance.cliveType;
        cliveChanger.changeCloneable = Clive.instance.cloneable;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Clive"))
        {
            cliveChanger.ExecuteOnActivate();
            other.GetComponent<Clive>().UpdateCliveType(cliveChanger.changeCliveType);

            ResetClive(other);
        }
    }

    public void ResetClive(Collider clive)
    {
        clive.GetComponent<Clive>().cliveActive = true;
        clive.GetComponent<Clive>().cliveActiveChanged = true;
    }
}
