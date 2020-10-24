using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    // Use this for initialization
    public GameObject title = null;
    public GameObject title1 = null;
    public int count = 0;
    // Update is called once per frame
    void OnMouseDown() {
        title.SetActive(false);
        title1.SetActive(true);
        count = 1;
        
    }
}
