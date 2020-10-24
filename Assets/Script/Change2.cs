using UnityEngine;
using System.Collections;

public class Change2 : MonoBehaviour {
    public Animator button;
    public GameObject screen;
    public GameObject screen1;
    void OnMouseOver()
    { button.SetBool("Check", true); }
    void OnMouseExit()
    { button.SetBool("Check", false); }
    // Use this for initialization
    /*
    void OnMouseDown()
    {
        screen1.SetActive(false);
        screen.SetActive(true);
#pragma warning disable CS0618 // Type or member is obsolete
        Application.LoadLevel("main4");
        #pragma warning restore CS0618 // Type or member is obsolete
    }
    */



    void OnCollisionEnter(Collision other)
    {
        if (other.transform.parent.parent.tag == "Hand")
        {
            screen1.SetActive(false);
            screen.SetActive(true);
            Guide.assemblyNumber = 0;
            #pragma warning disable CS0618 // Type or member is obsolete
            Application.LoadLevel("main4");
            #pragma warning restore CS0618 // Type or member is obsolete
        }
    }
}
