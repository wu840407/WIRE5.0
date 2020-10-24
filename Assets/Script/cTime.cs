using UnityEngine;
using System.Collections;

public class cTime : MonoBehaviour {
    public float ctime = 0f;
    public GameObject q = null;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        ctime += Time.deltaTime;
        if (ctime >= 22.5)
        {
            q.SetActive(true);

        }

    }
}
