using UnityEngine;
using System.Collections;

public class back : MonoBehaviour
{

    // Use this for initialization
    public GameObject button;
    public GameObject text;
    public GameObject text1;
    // Update is called once per frame
    void OnGUI()
    {


        UIEventListener.Get(button).onClick = ButtonClick;


    }
    void ButtonClick(GameObject button)
    {
        StartCoroutine("ScoreDownload");
    }
    void ScoreDownload()
    {
        UserLogin.a = 0;
        text.GetComponent<UILabel>().text = "Sign in your ID";
        text1.GetComponent<UILabel>().text = "Sign in your Password";
    }
}