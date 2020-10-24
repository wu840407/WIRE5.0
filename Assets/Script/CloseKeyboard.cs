using UnityEngine;
using System.Collections;

public class CloseKeyboard : MonoBehaviour {

    public GameObject CloseButton;
    public Material oringenCubeMaterial;
    public Material selectCubeMaterial;
    public GameObject callerCube;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.parent.tag == "Hand")
        {
            callerCube.GetComponent<MeshRenderer>().material = oringenCubeMaterial;
            CloseButton.transform.parent.parent.gameObject.SetActive(false);
            callerCube.transform.parent.parent.GetComponent<triggerControler>().triggerEnable();
        }
    }
}
