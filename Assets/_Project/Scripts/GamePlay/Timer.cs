using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public int TotalTime;
    

    private int minute;
    private int second;

    public Text TimeText;


    private void Start()
    {
        InvokeRepeating("ReverseCountdown_IR", 0,1);
    }

    private void ReverseCountdown_IR() {
        if (TotalTime > 0)
        {
            TotalTime--;
            minute = TotalTime / 60;
            second = TotalTime - minute * 60;
            if (second < 10)
            {
                TimeText.text = minute.ToString() + ":0" + second.ToString();
            }
            else
                TimeText.text = minute.ToString() + ":" + second.ToString();
        }
        else {
            //stop game show result

            CancelInvoke("ReverseCountdown_IR");
        }
    }

}
