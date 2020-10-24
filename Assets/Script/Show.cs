using UnityEngine;
using System.Collections;

public class Show : MonoBehaviour {
    public int a = 0;
    public GameObject show1;
    public GameObject show2;
    public GameObject show3;
    public GameObject show4;
    public GameObject show5;
    public GameObject show6;
    public GameObject show7;
    public GameObject show8;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void OnClick() {
        if (a == 0)
        {
            show1.SetActive(false);
            show2.SetActive(false);
            show3.SetActive(false);
            show4.SetActive(false);
            show5.SetActive(false);
            show6.SetActive(false);
            show7.SetActive(false);
            show8.SetActive(false);
        }
        if (a == 1)
        {
            show1.SetActive(true);
            show2.SetActive(false);
            show3.SetActive(false);
            show4.SetActive(false);
            show5.SetActive(false);
            show6.SetActive(false);
            show7.SetActive(false);
            show8.SetActive(false);
        }
        if (a == 2)
        {
            show1.SetActive(false);
            show2.SetActive(true);
            show3.SetActive(false);
            show4.SetActive(false);
            show5.SetActive(false);
            show6.SetActive(false);
            show7.SetActive(false);
            show8.SetActive(false);
        }
        if (a == 3)
        {
            show1.SetActive(false);
            show2.SetActive(false);
            show3.SetActive(true);
            show4.SetActive(false);
            show5.SetActive(false);
            show6.SetActive(false);
            show7.SetActive(false);
            show8.SetActive(false);
        }
        if (a == 4)
        {
            show1.SetActive(false);
            show2.SetActive(false);
            show3.SetActive(false);
            show4.SetActive(true);
            show5.SetActive(false);
            show6.SetActive(false);
            show7.SetActive(false);
            show8.SetActive(false);
        }
        if (a == 5)
        {
            show1.SetActive(false);
            show2.SetActive(false);
            show3.SetActive(false);
            show4.SetActive(false);
            show5.SetActive(true);
            show6.SetActive(false);
            show7.SetActive(false);
            show8.SetActive(false);
        }
        if (a == 6)
        {
            show1.SetActive(false);
            show2.SetActive(false);
            show3.SetActive(false);
            show4.SetActive(false);
            show5.SetActive(false);
            show6.SetActive(true);
            show7.SetActive(false);
            show8.SetActive(false);
        }
        if (a ==7)
        {
            show1.SetActive(false);
            show2.SetActive(false);
            show3.SetActive(false);
            show4.SetActive(false);
            show5.SetActive(false);
            show6.SetActive(false);
            show7.SetActive(true);
            show8.SetActive(false);
        }
        if (a == 8)
        {
            show1.SetActive(false);
            show2.SetActive(false);
            show3.SetActive(false);
            show4.SetActive(false);
            show5.SetActive(false);
            show6.SetActive(false);
            show7.SetActive(false);
            show8.SetActive(true);
        }
    }
}
