using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ButtonText : MonoBehaviour {

    public GameObject keyboard;
    public GameObject keyboardText;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
	    if(keyboard != null)
        {
            GetComponent<Text>().text = keyboardText.GetComponent<Text>().text;
            if(keyboard.active == false)
            {
                keyboard = null;
            }
        }
	}
}
