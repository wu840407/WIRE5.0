using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using System.Runtime.InteropServices;
using System;
public class UserUI : MonoBehaviour
{
    [DllImport("iow_work", EntryPoint = "initialServer")]
    public static extern int initialServer(IntPtr account, IntPtr password);

    [DllImport("iow_work", EntryPoint = "CreateUser")]
    public static extern int CreateUser(IntPtr new_userName, IntPtr new_account, IntPtr new_password);



    private string path = "http://140.132.34.22/Unity/RankingUpdate.php";
    // Use this for initialization
    public GameObject label1;
    public GameObject label2;
    public GameObject label3;
    public GameObject label4;
    public GameObject button;
    public GameObject check;
    public GameObject CreateWindowLabel;
    public string M_Name;
    public char a;
    public string ID;
    public string Password;
    public string Password1;
    void OnGUI()
    {
        ID = label1.GetComponent<UILabel>().text;
        Password = label2.GetComponent<UILabel>().text;
        M_Name = label3.GetComponent<UILabel>().text;
        Password1 = label4.GetComponent<UILabel>().text;
        if (Password == Password1 && Password != "Sign in your Password")
        {
            button.SetActive(true);
            check.GetComponent<UILabel>().text = "";
            UIEventListener.Get(button).onClick = ButtonClick;
        }
        else
        {
            if (Password != "Sign in your Password" && Password1 != "Sign in your Password")
            {
                button.SetActive(false);
                check.GetComponent<UILabel>().text = "密碼輸入錯誤";
            }

        }

    }
    void ButtonClick(GameObject button)
    {
        StartCoroutine("ScoreUpdate");
    }
    public IEnumerator ScoreUpdate()
    {
        /*
        WWWForm form = new WWWForm();
        Dictionary<string, string> data = new Dictionary<string, string>();
        data.Add("ID", ID);
        data.Add("Password", Password);
        data.Add("M_Name", M_Name);
       
        foreach (KeyValuePair<string, string> post in data)
        {
            form.AddField(post.Key, post.Value);
        }

        WWW www = new WWW(path, form);
        yield return www;
        Debug.Log(www.text);
        */


        Debug.Log("Begin CreateUser");

        bool isInitial = false, isCreate = false;

        String DB_account = "root";
        String DB_password = "";
        IntPtr DB_accountPtr = (IntPtr)Marshal.StringToHGlobalAnsi(DB_account);
        IntPtr DB_passwordPtr = (IntPtr)Marshal.StringToHGlobalAnsi(DB_password);

        if (initialServer(DB_accountPtr, DB_passwordPtr) == -1)
        {
            Debug.Log("initialServer fail");
        }
        else
        {
            Debug.Log("initialServer success");
            isInitial = true;
        }

        IntPtr User_NamePtr = (IntPtr)Marshal.StringToHGlobalAnsi(M_Name);
        IntPtr User_accountPtr = (IntPtr)Marshal.StringToHGlobalAnsi(ID);
        IntPtr User_passwordPtr = (IntPtr)Marshal.StringToHGlobalAnsi(Password);

        if (CreateUser(User_NamePtr, User_accountPtr, User_passwordPtr) == -1)
        {
            Debug.Log("CreateUser fail");
        }
        else
        {
            Debug.Log("CreateUser success");
            isCreate = true;
        }

        if (isInitial && isCreate)
        {
            CreateWindowLabel.GetComponent<UILabel>().text = "建立成功";
        }
        else
        {
            CreateWindowLabel.GetComponent<UILabel>().text = "建立失敗";
        }

        Debug.Log("End CreateUser");

        yield break;
    }
}
