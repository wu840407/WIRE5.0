using UnityEngine;
using System.Collections;

public class Change3 : MonoBehaviour {
    public GameObject scene;
    public GameObject scene1;
    // Use this for initialization
    void OnClick()
    {
        scene.SetActive(true);
        scene1.SetActive(false);
        Application.LoadLevel("main5");
    }
}
