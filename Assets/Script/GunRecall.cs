using UnityEngine;
using System.Collections;

public class GunRecall : MonoBehaviour {
    public GameObject gunPart;
    Material material;
    public Material Transparent;
    public Material DeepTransparent;
    float time = 0;
    bool isRunTimer = false;
	// Use this for initialization
	void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
        if(gunPart.active == false)
        {
            MeshRenderer renderer = GetComponent<MeshRenderer>();
            renderer.material = Transparent;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        
        if (gunPart.active)
        {
            return;
        }
        if (other.transform.parent.parent.tag == "Hand")
        {
            MeshRenderer renderer = GetComponent<MeshRenderer>();
            renderer.material = DeepTransparent;

            gunPart.SetActive(true);
        }
    }
}
