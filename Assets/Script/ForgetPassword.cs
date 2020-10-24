using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class ForgetPassword : MonoBehaviour
{
    [DllImport("iow_work", EntryPoint = "initialServer")]
    public static extern int initialServer(IntPtr account, IntPtr password);

    [DllImport("iow_work", EntryPoint = "GetPassword")]
    public static extern IntPtr GetPassword(IntPtr ID, IntPtr userName);

    public GameObject NameInupt;
    public GameObject AccountInupt;
    public GameObject OptionScreen;
    public bool SearchSuccess = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.parent.tag == "Hand")
        {
            Debug.Log("Begin GetPassword");
            
            //IntPtr aaa = new IntPtr();
            //Marshal.WriteInt32(aaa, 123);
            //Debug.Log("aaaaaa" + aaa);
            /*
            int bbb = Marshal.ReadInt32(aaa);
            Debug.Log("bbbbbb" + bbb);
            */
            string Name = NameInupt.GetComponent<Text>().text;
            string Account = AccountInupt.GetComponent<Text>().text;
            Text OptionMessage = OptionScreen.transform.FindChild("OptionCanvas").FindChild("Message").GetComponent<Text>();
            triggerControler controler = this.transform.parent.parent.GetComponent<triggerControler>();

            if (Name == "" || Account == "")
            {
                OptionScreen.SetActive(true);
                controler.triggerDisable();
                OptionMessage.text = "資料不能為空";
                Debug.Log("Data Empty");
                Debug.Log("End CreateUser");
                return;
            }
            else if (!CheckInfoFormat(Name, Account))
            {
                OptionScreen.SetActive(true);
                controler.triggerDisable();
                OptionMessage.text = "資料格式錯誤" + Environment.NewLine + "只能數字或字母";
                Debug.Log("Password Error");
                Debug.Log("End CreateUser");
                return;
            }

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

            IntPtr User_accountPtr = (IntPtr)Marshal.StringToHGlobalAnsi(Account);
            IntPtr User_userNamePtr = (IntPtr)Marshal.StringToHGlobalAnsi(Name);

            IntPtr User_returnPasswordPtr = GetPassword(User_accountPtr, User_userNamePtr);
            string User_password = "";

            User_password = (string)Marshal.PtrToStringAnsi(User_returnPasswordPtr);

            Debug.Log("aAA: " + User_password);

            if (User_password == null)
            {
                Debug.Log("GetPassword fail");
            }
            else
            {
                Debug.Log("GetPassword success");
                hasPassword = true;
            }

            if (isInitial)
            {
                if (hasPassword)
                {
                    OptionMessage.text = "查詢成功" + Environment.NewLine + "密碼:" + User_password;
                    SearchSuccess = true;
                }
                else
                {
                    OptionMessage.text = "查尋失敗" + Environment.NewLine + "輸入資料不符";
                }
                
            }
            else
            {
                OptionMessage.text = "資料庫連接失敗";
            }
            controler.triggerDisable();
            OptionScreen.SetActive(true);

            Debug.Log("End GetPassword");
        }
    }

    bool IsAlphaNumeric(String InputString)
    {
        return (InputString != string.Empty && !Regex.IsMatch(InputString, "[^a-zA-Z0-9]"))
            ? true : false;
    }

    bool CheckInfoFormat(string Name, string Account)
    {
        return (IsAlphaNumeric(Name) && IsAlphaNumeric(Account));
    }
}
