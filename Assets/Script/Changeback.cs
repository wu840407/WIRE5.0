using UnityEngine;
using System.Collections;

public class Changeback : MonoBehaviour {

    // Use this for initialization
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.parent.tag == "Hand")
        {
#pragma warning disable CS0618 // Type or member is obsolete
            Application.LoadLevel("main1");
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }
}
