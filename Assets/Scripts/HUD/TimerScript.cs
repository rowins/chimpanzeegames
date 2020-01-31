using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public TextMeshProUGUI Timer;
    public int currentTime;
    public GameObject Score;
    public Score ScoreScript;
    public int minutes;
    public int seconds;
    public double hundreths;

    // Use this for initialization
    void Start()
    {
        ScoreScript = Score.GetComponent<Score>();
        Timer = GetComponent<TextMeshProUGUI>();
        Timer.text = minutes + ":" + seconds + ":" + hundreths;
    }

    // Convert time so it can be displayed in the correct manner
    void Update()
    {
        minutes = Convert.ToInt32(Math.Floor(ScoreScript.minutes));
        seconds = Convert.ToInt32(Math.Floor(ScoreScript.seconds));
        hundreths = Convert.ToInt32(Math.Floor((ScoreScript.seconds-seconds)*100));

        if(seconds < 10)
        {
            Timer.text = "0" + minutes + ":0" + seconds + ":" + hundreths;
        } else
        {
            Timer.text = "0" + minutes + ":" + seconds + ":" + hundreths;
        }

    }
}


