using UnityEngine;
using System.Collections;

public class CloseOption : MonoBehaviour {
    public GameObject ComfirmObject;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.parent.tag == "Hand")
        {
            Component component = new Component();
            if (Application.loadedLevelName == "main2")
            {
                component = ComfirmObject.GetComponent<CreateAccount>();
            }
            else if(Application.loadedLevelName == "main3")
            {
                component = ComfirmObject.GetComponent<ForgetPassword>();
            }
            

            triggerControler controler = this.transform.parent.parent.parent.GetComponent<triggerControler>();
            GameObject OptionScreen = this.transform.parent.gameObject;

            controler.triggerEnable();
            OptionScreen.SetActive(false);

            if(Application.loadedLevelName == "main2")
            {
                CreateAccount CA = component as CreateAccount;
                if (CA.CreateSuccess == true)
                {
                    #pragma warning disable CS0618 // Type or member is obsolete
                    Application.LoadLevel("main1");
                    #pragma warning restore CS0618 // Type or member is obsolete
                }
            }
            else if (Application.loadedLevelName == "main3")
            {
                ForgetPassword FA = component as ForgetPassword;
                if (FA.SearchSuccess == true)
                {
                    #pragma warning disable CS0618 // Type or member is obsolete
                    Application.LoadLevel("main1");
                    #pragma warning restore CS0618 // Type or member is obsolete
                }
            }

            
        }

    }
}
