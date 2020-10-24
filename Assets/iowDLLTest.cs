using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System;
public class iowDLLTest : MonoBehaviour {

    [DllImport("IOW_work_dll", EntryPoint = "TwJoinIOW")]
    public static extern int TwJoinIOW(int Int_ClientType, IntPtr CharAry_iID);

    [DllImport("IOW_work_dll", EntryPoint = "TwJoinApplication")]
    public static extern int TwJoinApplication();

    [DllImport("IOW_work_dll", EntryPoint = "TwLeaveApplication")]
    public static extern int TwLeaveApplication();

    [DllImport("IOW_work_dll", EntryPoint = "TwLeaveIOW")]
    public static extern int TwLeaveIOW();

    [DllImport("IOW_work_dll", EntryPoint = "TwInteractionEnable")]
    public static extern int TwInteractionEnable();

    [DllImport("IOW_work_dll", EntryPoint = "TwInteractionDisable")]
    public static extern int TwInteractionDisable();
    //-------------------------------------------------

    //-------------------------------------------------
    [DllImport("IOW_work_dll", EntryPoint = "GID")]
    public static extern int GID();

    [DllImport("IOW_work_dll", EntryPoint = "AppGID")]
    public static extern IntPtr AppGID();
    //-------------------------------------------------

    int count = 0;
    // Use this for initialization
    void Start () {
        //string DID = "abcd:qwer:3344";
        //IntPtr DID_Ptr = (IntPtr)Marshal.StringToHGlobalAnsi(DID);
        //Debug.Log(TwInitial(DID_Ptr));
        EnterIOW();
    }
	
	// Update is called once per frame
	void Update () {
        /*
        if (count == 100)
        {
            EnterIOW();
        }
        else
        {
            Debug.Log(count);
        }
        count++;
        */
    }

    void EnterIOW()
    {
        string DID = "abcd:qwer:3344";
        IntPtr DID_Ptr = (IntPtr)Marshal.StringToHGlobalAnsi(DID);
        //int Int_NewGID = GID();
        int returnJoin = TwJoinIOW(1, DID_Ptr);
        int returnApp = TwJoinApplication();

        int returnGID = GID();

        IntPtr returnPtr = AppGID();
        string PtrStr = "";
        PtrStr = (string)Marshal.PtrToStringAnsi(returnPtr);
        Debug.Log(returnJoin);
        Debug.Log(returnApp);
        Debug.Log(returnGID);
        Debug.Log(PtrStr);

        int EventEn = TwInteractionEnable();
        Debug.Log(EventEn);
        int EventDis = TwInteractionDisable();
        Debug.Log(EventDis);

        int leaveValue = TwLeaveApplication();
        Debug.Log(leaveValue);
        int leaveIOWValue = TwLeaveIOW();
        Debug.Log(leaveIOWValue);
    }
}
