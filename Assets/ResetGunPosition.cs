using UnityEngine;
using System.Collections;

public class ResetGunPosition : MonoBehaviour {
    public Transform[] gunTransform;
    public Transform[] originGunTransform;
    // Update is called once per frame
    bool isRunTimer = false;
    float time = 0;

    void Update()
    {
        if (time > 2)
        {
            isRunTimer = false;
            time = 0;
        }
        if (isRunTimer)
        {
            time += Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.transform.parent.parent.tag == "Hand")
        {
            if (isRunTimer)
            {
                return;
            }
            int i = Guide.assemblyNumber + 1;
            gunTransform[0].position = originGunTransform[0].position;
            gunTransform[0].rotation = originGunTransform[0].rotation;
            while (i < 8)
            {
                gunTransform[i].gameObject.SetActive(false);
                
                gunTransform[i].position = originGunTransform[i].position;
                gunTransform[i].rotation = originGunTransform[i].rotation;
                            
                i++;
            }
            isRunTimer = true;
        }
        
    }
}
