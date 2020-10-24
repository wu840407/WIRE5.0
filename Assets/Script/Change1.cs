using UnityEngine;
using System.Collections;

public class Change1 : MonoBehaviour {

    // Use this for initialization
    void OnTriggerEnter()
    {
#pragma warning disable CS0618 // Type or member is obsolete
        Application.LoadLevel("main3");
#pragma warning restore CS0618 // Type or member is obsolete
    }
}
