using UnityEngine;
using System.Collections;

public class CombineEnded : MonoBehaviour {

    public GameObject FinGun;
    public GameObject MainCanva;
    public GameObject trans;
    public GameObject BackButton;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (FinGun.GetComponent<Guide>().isFinished == true)
        {
            MainCanva.SetActive(true);
            BackButton.transform.position = trans.transform.position;
            BackButton.transform.rotation = trans.transform.rotation;
        }
	}
}
