using UnityEngine;
using System.Collections;

public class GunRotate : MonoBehaviour {
    GameObject gunPart;
    Transform partTransform; 
	// Use this for initialization
	void Start () {
        gunPart = this.gameObject;
        partTransform = gunPart.transform;
    }
	
	// Update is called once per frame
	void Update () {
        partTransform.transform.Rotate(new Vector3(0, 1, 0));

    }
}
