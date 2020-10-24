using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using System.Runtime.InteropServices;
using System;

public class UserLogin : MonoBehaviour
{
    [DllImport("iow_work", EntryPoint = "Login")]
    private static extern int Login(IntPtr user, IntPtr userpassword);

    [DllImport("iow_work", EntryPoint = "initialServer")]
    public static extern int initialServer(IntPtr account, IntPtr password);


    [DllImport("iow_work", EntryPoint = "GetUserInfo")]
    public static extern IntPtr GetUserInfo(IntPtr account);


    private string userLogin = "http://140.132.34.22/Unity/RankingDownload.php";
    // Use this for initialization
    public GameObject label1;
    public GameObject label2;
    public static string ID;
    public string Password;
    public static string M_Name;
    public GameObject button;
    public GameObject scene;
    public GameObject scene1;
    public GameObject button1;
    public GameObject button2;
    public GameObject name1;
    public GameObject view;
    public GameObject view1;
    public static int a = 0;
    void Update()
    {
        if (a == 1)
        {
            view.SetActive(false);
            view1.SetActive(true);
            name1.GetComponent<UILabel>().text = M_Name;
        }
        else
        {
            view1.SetActive(false);
            view.SetActive(true);

        }
    }
    void OnGUI()
    {

        ID = label1.GetComponent<UILabel>().text;
        Password = label2.GetComponent<UILabel>().text;
        if (Password != "Sign in your Password" && ID != "Sign in your ID")
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
        data.Add("Password", Password);
        foreach (KeyValuePair<string, string> post in data)
        {
            form.AddField(post.Key, post.Value);
        }

        WWW www = new WWW(userLogin, form);
        yield return www;
        Debug.Log(www.text);
        JsonData json = JsonMapper.ToObject<JsonData>(www.text);
        Debug.Log(json);

        string jsc = json[0].ToString();
        Debug.Log(jsc);
        */
        

        Debug.Log("Begin login");

        bool isInitial = false, isLogin = false;

        String DB_account = "root";
        String DB_password = "";
        IntPtr DB_accountPtr = (IntPtr)Marshal.StringToHGlobalAnsi(DB_account);
        IntPtr DB_passwordPtr = (IntPtr)Marshal.StringToHGlobalAnsi(DB_password);

        int returnValue = initialServer(DB_accountPtr, DB_passwordPtr);

        if (returnValue == -1)
        {
            Debug.Log("initialServer fail");
            
        }
        else
        {
            Debug.Log("initialServer success");
            isInitial = true;
        }

        IntPtr User_accountPtr = (IntPtr)Marshal.StringToHGlobalAnsi(ID);
        IntPtr User_passwordPtr = (IntPtr)Marshal.StringToHGlobalAnsi(Password);
        if (isInitial) {
            

            if (Login(User_accountPtr, User_passwordPtr) == -1)
            {
                Debug.Log("Login fail");
            }
            else
            {
                Debug.Log("Login success");
                isLogin = true;
            }
        }


        //if (jsc == "1")
        if (isInitial)
        {
            if (isLogin)
            {
                IntPtr User_InfoPtr = GetUserInfo(User_accountPtr);
                string User_InfoStr = (string)Marshal.PtrToStringAnsi(User_InfoPtr);

                string[] User_Info_Arr = User_InfoStr.Split(',');

                a = 1;
                //M_Name = json[3].ToString();
                //name1.GetComponent<UILabel>().text= json[3].ToString();
                M_Name = User_Info_Arr[0];
                name1.GetComponent<UILabel>().text = User_Info_Arr[0];
                M_Name = name1.GetComponent<UILabel>().text;
                scene1.GetComponent<UILabel>().text = "Password correct.";
                scene.SetActive(true);
                button1.SetActive(true);
                button2.SetActive(false);
            }
            else
            {
                a = 0;
                scene1.GetComponent<UILabel>().text = "Password incorrect.";
                scene.SetActive(true);
                button2.SetActive(true);
                button1.SetActive(false);
            }
        }
        else
        {
            a = 0;
            scene1.GetComponent<UILabel>().text = "Initial server fail.";
            scene.SetActive(true);
            button2.SetActive(true);
            button1.SetActive(false);
        }
       
        yield break;
    }
}
