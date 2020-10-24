using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {
    public GameObject Label1;
    public GameObject Label2;
    public GameObject Label3;
    public GameObject scence;
    public GameObject scence1;
    public string Text;
    public string Text1;
    public GameObject gun1;
    public int ww;
    // Use this for initialization
    void OnHover () {
        Label1.GetComponent<UILabel>().text = Text;
	}
	
	// Update is called once per frame
	void OnClick () {
        Label3.GetComponent<UILabel>().text = Text;
        Label2.GetComponent<UILabel>().text = Text1;
        scence.SetActive(false);
        scence1.SetActive(true);
        gun1.GetComponent<Show>().a=ww;

    }
}
