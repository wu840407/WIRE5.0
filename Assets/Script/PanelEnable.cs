using UnityEngine;
using System.Collections;

public class PanelEnable : MonoBehaviour {

    public GameObject panel;

    int count = 0;
    bool isRunTimer = false;
    float time = 0;


	// Use this for initialization
	void Start () {
	
	}
	
    

	// Update is called once per frame
	void Update () {
        if(time > 2)
        {
            isRunTimer = false;
            time = 0;
        }
        if (isRunTimer)
        {
            time += Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.parent.tag == "Hand")
        {
            if (isRunTimer)
            {
                return;
            }
            if (panel.active)
            {
                panel.SetActive(false);
            }
            else
            {
                panel.SetActive(true);
            }
            isRunTimer = true;
        }
    }
}
