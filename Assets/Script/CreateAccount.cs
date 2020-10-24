using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class CreateAccount : MonoBehaviour {

    [DllImport("iow_work", EntryPoint = "initialServer")]
    public static extern int initialServer(IntPtr account, IntPtr password);

    [DllImport("iow_work", EntryPoint = "CreateUser")]
    public static extern int CreateUser(IntPtr new_userName, IntPtr new_account, IntPtr new_password);


    public GameObject NameInupt;
    public GameObject AccountInupt;
    public GameObject PasswordInupt;
    public GameObject CheckPasswordInupt;
    public GameObject OptionScreen;
    public bool CreateSuccess = false;

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
            string Name = NameInupt.GetComponent<Text>().text;
            string Account = AccountInupt.GetComponent<Text>().text;
            string Password = PasswordInupt.GetComponent<Text>().text;
            string CheckPassword = CheckPasswordInupt.GetComponent<Text>().text;
            Text OptionMessage = OptionScreen.transform.FindChild("OptionCanvas").FindChild("Message").GetComponent<Text>();
            triggerControler controler = this.transform.parent.parent.GetComponent<triggerControler>();

            if (Name == "" || Account == "" || Password == "") {
                OptionScreen.SetActive(true);
                controler.triggerDisable();
                OptionMessage.text = "資料不能為空";
                Debug.Log("Data Empty");
                Debug.Log("End CreateUser");
                return;
            }
            else if (Password != CheckPassword)
            {
                OptionScreen.SetActive(true);
                controler.triggerDisable();
                OptionMessage.text = "密碼不相等";
                Debug.Log("Password Not Equal");
                Debug.Log("End CreateUser");
                return;
            }
            else if (TryParseInt(Password) == false)
            {
                OptionScreen.SetActive(true);
                controler.triggerDisable();
                OptionMessage.text = "輸入密碼必須為數字";
                Debug.Log("Password Error");
                Debug.Log("End CreateUser");
                return;
            }
            else if (!CheckInfoFormat(Name,Account,Password))
            {
                OptionScreen.SetActive(true);
                controler.triggerDisable();
                OptionMessage.text = "資料格式錯誤" + Environment.NewLine + "只能數字或字母";
                Debug.Log("Password Error");
                Debug.Log("End CreateUser");
                return;
            }

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

            IntPtr User_NamePtr = (IntPtr)Marshal.StringToHGlobalAnsi(Name);
            IntPtr User_accountPtr = (IntPtr)Marshal.StringToHGlobalAnsi(Account);
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

            

            if (isInitial)
            {
                if (isCreate)
                {
                    OptionMessage.text = "創建成功";
                    CreateSuccess = true;
                }
                else
                {
                    OptionMessage.text = "創建失敗";
                }
            }
            else
            {
                OptionMessage.text = "資料庫連接失敗";
            }
            controler.triggerDisable();
            OptionScreen.SetActive(true);


            Debug.Log("End CreateUser");
        }
    }

    bool TryParseInt(string str)
    {
        int number = 0;
        bool result = int.TryParse(str, out number);

        return result;
    }

    bool IsAlphaNumeric(String InputString)
    {
        return (InputString != string.Empty && !Regex.IsMatch(InputString, "[^a-zA-Z0-9]"))
            ? true : false;
    }

    bool CheckInfoFormat(string Name,string Account ,string Passwrod)
    {
        return (IsAlphaNumeric(Name) && IsAlphaNumeric(Account) && IsAlphaNumeric(Passwrod));
    }

}


