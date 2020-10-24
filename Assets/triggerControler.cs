using UnityEngine;
using System.Collections;

public class triggerControler : MonoBehaviour {

    public GameObject[] triggerOwner;

    // Use this for initialization
    void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}

    public void triggerEnable()
    {
        foreach(GameObject owner in triggerOwner)
        {
            owner.GetComponent<Collider>().isTrigger = true;
        }
    }

    public void triggerDisable()
    {
        foreach (GameObject owner in triggerOwner)
        {
            owner.GetComponent<Collider>().isTrigger = false;
        }
    }
}
