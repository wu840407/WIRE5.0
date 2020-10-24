using UnityEngine;
using System.Collections;

public class Change : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter(){
        #pragma warning disable CS0618 // Type or member is obsolete
        Application.LoadLevel("main2");
        #pragma warning restore CS0618 // Type or member is obsolete
    }
}
