using UnityEngine;
using System.Collections;

public class defeat : MonoBehaviour {
    public GameObject label;
    public GameObject defeat1;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(label.GetComponent<UILabel>().text=="00:10:00")
        {
            defeat1.SetActive(true);
            label.SetActive(false);
        }
	}
}
