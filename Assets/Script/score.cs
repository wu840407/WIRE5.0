using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System;
public class score : MonoBehaviour
{
    [DllImport("iow_work", EntryPoint = "DataUpdate")]
    public static extern int DataUpdate(IntPtr gun_name, IntPtr m_name, IntPtr id, int complete_time, int score);

    private string path = "http://140.132.34.22/Unity/Score.php";
    public int count = 0;
    public float count1 = 0;
    public GameObject time = null;
    public string time1;
    public string time2;
    public GameObject place;
    public GameObject score1;
    public GameObject GetGuide;

    private bool isSend;

    // Use this for initialization
    void Start()
    {
        isSend = false;
    }

    // Update is called once per frame
    void Update()
    {     
        if (GetGuide.GetComponent<Guide>().isFinished && !isSend)
        {
            count = 1;
            isSend = true;
        }

        if (count == 1)
        {
            Scorecount();
        }
    }
    void Scorecount()
    {

        count = 0;
        time1 = time.GetComponent<SurvivalTimer>().timerText1;
        time.GetComponent<SurvivalTimer>().enabled = false;
        place.SetActive(true);
        count1 = (600 - time.GetComponent<SurvivalTimer>().temp) / 600 * 100;
        score1.GetComponent<UILabel>().text = "成績: " + count1.ToString("#0.00") + "  分";
        ScoreUpdate1();
    }
    void ScoreUpdate1()
    {
        Debug.Log("ScoreUpdate1");
        StartCoroutine("ScoreUpdate");
        Debug.Log("ScoreUpdate2");

    }
    public IEnumerator ScoreUpdate()
    {
        /*
        WWWForm form = new WWWForm();
        Dictionary<string, string> data = new Dictionary<string, string>();
        data.Add("M_Name", UserLogin.M_Name);
        data.Add("Complete_time", time.GetComponent<SurvivalTimer>().timerText);
        data.Add("Score", count1.ToString("#0.00"));
        foreach (KeyValuePair<string, string> post in data)

        {
            form.AddField(post.Key, post.Value);
        }

        WWW www = new WWW(path, form);
        yield return www;
        Debug.Log(www.text);
        */
        Debug.Log("Begin DataUpdate");



        string[] timeSep = time1.Split('.');
        int time = Convert.ToInt32(timeSep[0]);
        int score = Convert.ToInt32(count1);
        IntPtr GunPtr = (IntPtr)Marshal.StringToHGlobalAnsi("T74");
        Debug.Log(UserLogin.M_Name);
        IntPtr NamePtr = (IntPtr)Marshal.StringToHGlobalAnsi(UserLogin.M_Name);
        Debug.Log(UserLogin.ID);
        IntPtr IDPtr = (IntPtr)Marshal.StringToHGlobalAnsi(UserLogin.ID);

        int rv = DataUpdate(GunPtr, NamePtr, IDPtr,time, score);

        if (rv != 0)
        {
            Debug.Log("DataUpdate fail");
        }
        else
        {
            Debug.Log("DataUpdate success");
        }

        yield break;
    }
}
