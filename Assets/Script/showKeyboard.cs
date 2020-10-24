using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;

public class showKeyboard : MonoBehaviour {

    public GameObject myKeyboard;
    public GameObject keyboardCaller;
    public GameObject closeButton;
    public Material oringenCubeMaterial;
    public Material selectCubeMaterial;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other) {
        if (myKeyboard.active == true)
        {
            return;
        }

        if (other.transform.parent.parent.tag == "Hand")
        {
            MeshRenderer renderer = GetComponent<MeshRenderer>();
            renderer.material = selectCubeMaterial;


            myKeyboard.SetActive(true);
            string callerText = keyboardCaller.GetComponent<Text>().text;
            if (callerText == "Sign in your ID" || callerText == "Sign in your Password")
            {
                keyboardCaller.GetComponent<Text>().text = "";
            }


            StringBuilder stringBuilder = myKeyboard.GetComponent<Keyboard>().stringBuilder;
            Text TextOut = myKeyboard.GetComponent<Keyboard>().TextOut;
            stringBuilder.Remove(0, stringBuilder.Length);
            stringBuilder.Append(keyboardCaller.GetComponent<Text>().text);
            if (TextOut != null) TextOut.text = stringBuilder.ToString();


            keyboardCaller.GetComponent<ButtonText>().keyboard = myKeyboard;
            closeButton.GetComponent<CloseKeyboard>().callerCube = this.gameObject;
            this.transform.parent.parent.GetComponent<triggerControler>().triggerDisable();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        
    }
}
