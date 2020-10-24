using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using System.Runtime.InteropServices;
using System;
public class scoreboard : MonoBehaviour
{

    [DllImport("iow_work", EntryPoint = "GetScoreBoard")]
    public static extern IntPtr GetScoreBoard(int times);

    private string Login = "http://140.132.34.22/Unity/Scoreboard.php";
    // Use this for initialization
    /*
    public GameObject label1;
    public GameObject label2;
    public GameObject label3;
    public GameObject label4;
    public GameObject label5;
    public GameObject label6;
    public GameObject label7;
    public GameObject label8;
    public GameObject label9;
    public GameObject label10;
    public GameObject label11;
    public GameObject score1;
    public GameObject score2;
    public GameObject score3;
    public GameObject score4;
    public GameObject score5;
    public GameObject score6;
    public GameObject score7;
    public GameObject score8;
    public GameObject score9;
    public GameObject score10;
    public GameObject score11;
    public GameObject time1;
    public GameObject time2;
    public GameObject time3;
    public GameObject time4;
    public GameObject time5;
    public GameObject time6;
    public GameObject time7;
    public GameObject time8;
    public GameObject time9;
    public GameObject time10;
    public GameObject time11;
    */
    public GameObject button;

    public static int scoreCount = 11;

    public GameObject[] names;
    public GameObject[] scores;
    public GameObject[] time;

    void Awake()
    {
        //names[0] = GameObject.FindWithTag("LabelTag");
    }

    void OnGUI()
    {

        UIEventListener.Get(button).onClick = ButtonClick;
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
        foreach (KeyValuePair<string, string> post in data)
        {
            form.AddField(post.Key, post.Value);
        }

        WWW www = new WWW(Login, form);
        yield return www;
        Debug.Log(www.text);
        JsonData json = JsonMapper.ToObject<JsonData>(www.text);
        label1.GetComponent<UILabel>().text= json[0][0].ToString();
        label2.GetComponent<UILabel>().text = json[1][0].ToString();
        label3.GetComponent<UILabel>().text = json[2][0].ToString();
        label4.GetComponent<UILabel>().text = json[3][0].ToString();
        label5.GetComponent<UILabel>().text = json[4][0].ToString();
        label6.GetComponent<UILabel>().text = json[5][0].ToString();
        label7.GetComponent<UILabel>().text = json[6][0].ToString();
        label8.GetComponent<UILabel>().text = json[7][0].ToString();
        label9.GetComponent<UILabel>().text = json[8][0].ToString();
        label10.GetComponent<UILabel>().text = json[9][0].ToString();
        label11.GetComponent<UILabel>().text = json[10][0].ToString();
        score1.GetComponent<UILabel>().text = json[0][1].ToString();
        score2.GetComponent<UILabel>().text = json[1][1].ToString();
        score3.GetComponent<UILabel>().text = json[2][1].ToString();
        score4.GetComponent<UILabel>().text = json[3][1].ToString();
        score5.GetComponent<UILabel>().text = json[4][1].ToString();
        score6.GetComponent<UILabel>().text = json[5][1].ToString();
        score7.GetComponent<UILabel>().text = json[6][1].ToString();
        score8.GetComponent<UILabel>().text = json[7][1].ToString();
        score9.GetComponent<UILabel>().text = json[8][1].ToString();
        score10.GetComponent<UILabel>().text = json[9][1].ToString();
        score11.GetComponent<UILabel>().text = json[10][1].ToString();
        time1.GetComponent<UILabel>().text = json[0][2].ToString();
        time2.GetComponent<UILabel>().text = json[1][2].ToString();
        time3.GetComponent<UILabel>().text = json[2][2].ToString();
        time4.GetComponent<UILabel>().text = json[3][2].ToString();
        time5.GetComponent<UILabel>().text = json[4][2].ToString();
        time6.GetComponent<UILabel>().text = json[5][2].ToString();
        time7.GetComponent<UILabel>().text = json[6][2].ToString();
        time8.GetComponent<UILabel>().text = json[7][2].ToString();
        time9.GetComponent<UILabel>().text = json[8][2].ToString();
        time10.GetComponent<UILabel>().text = json[9][2].ToString();
        time11.GetComponent<UILabel>().text = json[10][2].ToString();
        */

        Debug.Log("Begin GetScoreBoard");

        names = GameObject.FindGameObjectsWithTag("NameTag");
        scores = GameObject.FindGameObjectsWithTag("ScoreTag");
        time = GameObject.FindGameObjectsWithTag("TimeTag");

        IntPtr scoreBoard_Ptr = GetScoreBoard(11);
        string scoreBoard_Str = (string)Marshal.PtrToStringAnsi(scoreBoard_Ptr);
        string[] scoreBoard_Arr = scoreBoard_Str.Split('#');    //每筆資料用"#"區分

        for (int i = 0; i < scoreCount; i++)
        {
            if (scoreBoard_Arr.Length <= i)
            {
                names[i].GetComponent<UILabel>().text = "無"; //index 0為 M_Name
                scores[i].GetComponent<UILabel>().text = "0";    //index 3為 Score
                time[i].GetComponent<UILabel>().text = "0";  //index 5為 Complete_time
                continue;
            }

            string[] score_field = scoreBoard_Arr[i].Split(',');
            score_field[5] = score_field[5].Replace('@', '\0');

            Debug.Log("Score" + i + ":" + score_field[0] + ',' + score_field[1] + ',' + score_field[2] + ',' + score_field[3] + ',' + score_field[4] + ',' + score_field[5]);

            names[i].GetComponent<UILabel>().text = score_field[0]; //index 0為 M_Name
            scores[i].GetComponent<UILabel>().text = score_field[3];    //index 3為 Score
            time[i].GetComponent<UILabel>().text = score_field[5];  //index 5為 Complete_time


            Debug.Log(names[0].GetComponent<UILabel>().text);
        }

        Debug.Log(scoreBoard_Str);

        Debug.Log("End GetScoreBoard");

        yield break;
    }
}
