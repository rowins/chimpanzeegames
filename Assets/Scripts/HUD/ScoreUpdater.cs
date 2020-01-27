using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUpdater : MonoBehaviour
 {
    public TextMeshProUGUI Score;
    public int currentScore;

    // Use this for initialization
    void Start()
    {
        currentScore = 0;
        Score = GetComponent<TextMeshProUGUI>();
        Score.text = "Score: " + currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = "Score: " + currentScore.ToString();
    }

    public void addScore(int x = 100)
    {
        currentScore += x;
    }
 }

