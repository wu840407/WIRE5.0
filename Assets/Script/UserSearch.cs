using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System;
public class UserSearch : MonoBehaviour
{

    [DllImport("iow_work", EntryPoint = "initialServer")]
    public static extern int initialServer(IntPtr account, IntPtr password);

    [DllImport("iow_work", EntryPoint = "GetPassword")]
    public static extern IntPtr GetPassword(IntPtr ID, IntPtr userName);

    private string Login = "http://140.132.34.22/Unity/UserSearch.php";
    // Use this for initialization
    public GameObject label1;
    public GameObject label2;
    public GameObject text;
    public string ID;
    public string M_Name;
    public GameObject button;

    void OnGUI()
    {

        ID = label1.GetComponent<UILabel>().text;
        M_Name = label2.GetComponent<UILabel>().text;
        if (M_Name != "Sign in your Name" && ID != "Sign in your ID")
        {
            button.SetActive(true);

            UIEventListener.Get(button).onClick = ButtonClick;
        }
        else
        {

            button.SetActive(false);


        }
    }
    void ButtonClick(GameObject button)
    {
        StartCoroutine("ScoreDownload");
    }
    public IEnumerator ScoreDownload()
    {
        /*
        WWWForm form = new WWWForm();
        Dictionary<string, string> data = new Dictionary<string, string>();
        data.Add("Login", "1");
        data.Add("ID", ID);
        data.Add("M_Name", M_Name);

        foreach (KeyValuePair<string, string> post in data)
        {
            form.AddField(post.Key, post.Value);
        }

        WWW www = new WWW(Login, form);
        yield return www;
        text.GetComponent<UILabel>().text = www.text;
        */

        Debug.Log("Begin GetPassword");

        bool isInitial = false, hasPassword = false;

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

        IntPtr User_accountPtr = (IntPtr)Marshal.StringToHGlobalAnsi(ID);
        IntPtr User_userNamePtr = (IntPtr)Marshal.StringToHGlobalAnsi(M_Name);

        IntPtr User_returnPasswordPtr = GetPassword(User_accountPtr, User_userNamePtr);
        string User_password = "";

        User_password = (string)Marshal.PtrToStringAnsi(User_returnPasswordPtr);

        if (User_password == null)
        {
            Debug.Log("GetPassword fail");
        }
        else
        {
            Debug.Log("GetPassword success");
            hasPassword = true;
        }

        if (isInitial && hasPassword)
        {

            text.GetComponent<UILabel>().text = User_password;
        }
        else
        {
            User_password = "Password Not Found";
            text.GetComponent<UILabel>().text = User_password;
        }

        Debug.Log("End GetPassword");

        yield break;
    }
}

