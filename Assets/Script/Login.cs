using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System;
using UnityEngine.UI;
using Leap.Unity;

public class Login : MonoBehaviour {
    [DllImport("iow_work", EntryPoint = "Login")]
    private static extern int userLogin(IntPtr user, IntPtr userpassword);

    [DllImport("iow_work", EntryPoint = "initialServer")]
    public static extern int initialServer(IntPtr account, IntPtr password);


    [DllImport("iow_work", EntryPoint = "GetUserInfo")]
    public static extern IntPtr GetUserInfo(IntPtr account);

    public Animator button;
    public GameObject screen;
    public GameObject screen1;

    public GameObject accountText;
    public GameObject passwordText;
    public GameObject errorMessage;


    void OnMouseOver()
    { button.SetBool("Check", true); }
    void OnMouseExit()
    { button.SetBool("Check", false); }
    // Use this for initialization
    /*
    void OnMouseDown()
    {
        screen1.SetActive(false);
        screen.SetActive(true);
        
    }
    */

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.parent.tag == "Hand")
        {
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

            string ID = accountText.GetComponent<Text>().text;
            string Password = passwordText.GetComponent<Text>().text;
            IntPtr User_accountPtr = (IntPtr)Marshal.StringToHGlobalAnsi(ID);
            IntPtr User_passwordPtr = (IntPtr)Marshal.StringToHGlobalAnsi(Password);
            if (isInitial)
            {


                if (userLogin(User_accountPtr, User_passwordPtr) == -1)
                {
                    Debug.Log("Login fail");
                }
                else
                {
                    Debug.Log("Login success");
                    isLogin = true;
                }
            }


            Text errorText = errorMessage.GetComponent<Text>();
            if (isInitial)
            {
                if (isLogin)
                {
                    errorMessage.SetActive(false);
                    Debug.Log("begin game");
                    screen1.SetActive(false);
                    screen.SetActive(true);
                }
                else
                {
                    errorMessage.SetActive(true);
                    errorText.text = "帳號或密碼錯誤" + Environment.NewLine + "請重新輸入";
                }
            }
            else
            {
                errorMessage.SetActive(true);
                errorText.text = "資料庫初始化失敗" + Environment.NewLine + "請確認連線";
            }

            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.parent.parent.tag == "Hand")
        {
            if(other.transform.parent.GetComponent<RigidFinger>().fingerType == Leap.Finger.FingerType.TYPE_INDEX)
            {
                errorMessage.SetActive(false);
            }
        }
    }


    /*
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.parent.parent.tag == "Hand")
        {
            screen1.SetActive(false);
            screen.SetActive(true); 
        }
    }
    */
}
