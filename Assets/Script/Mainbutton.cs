using UnityEngine;
using System.Collections;

public class Mainbutton : MonoBehaviour {
    public GameObject element = null;
    public GameObject element1 = null;
    public GameObject element2 = null;
    public GameObject element3 = null;
    // Use this for initialization
    void OnClick()
    {
        element.SetActive(true);
        element1.SetActive(false);
        element2.SetActive(false);
        element3.SetActive(false);
    }
}
