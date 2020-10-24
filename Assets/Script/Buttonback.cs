using UnityEngine;
using System.Collections;

public class Buttonback : MonoBehaviour {
    public GameObject screen1;
    public GameObject screen2;
    public GameObject screen3;
    public GameObject screen4;
    void OnClick () {
        screen1.SetActive(true);
        screen2.SetActive(false);
        screen3.SetActive(false);
        screen4.SetActive(false);
    }
}
