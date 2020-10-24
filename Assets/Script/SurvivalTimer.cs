using UnityEngine;
using System.Collections;
using System; //#1

public class SurvivalTimer : MonoBehaviour
{
    public UILabel timerLabel; //#2
    public string timerText;
    public string timerText1;
    public float temp;

    void Start()
    {
        
    }

    void Update()
    {
        temp += Time.deltaTime; //#3
        TimeSpan timeSpan = TimeSpan.FromSeconds(temp); //#4
        TimeSpan timeSpan1 = TimeSpan.FromSeconds(temp);
        timerText = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
        timerText1 = temp.ToString();
        timerLabel.text = timerText; //#6

    }


}
