using UnityEngine;
using System.Collections;

public class GunBack : MonoBehaviour {
    public GameObject scence;
    public GameObject scence1;
    public GameObject gun;
    public GameObject gun1;
    public GameObject gun2;
    public GameObject gun3;
    public GameObject gun4;
    public GameObject gun5;
    public GameObject gun6;
    public GameObject gun7;
    // Use this for initialization
    void OnClick () {
        scence.SetActive(false);
        scence1.SetActive(true);
        gun.SetActive(false);
        gun1.SetActive(false);
        gun2.SetActive(false);
        gun3.SetActive(false);
        gun4.SetActive(false);
        gun5.SetActive(false);
        gun6.SetActive(false);
        gun7.SetActive(false);
    }
	
	// Update is called once per frame
	
}
