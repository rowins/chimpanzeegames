using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score;
    public int abonnees;
    public double gameTime = 0;
    public double minutes;
    public double seconds;
    public bool finished = false;

    // Update is called once per frame
    void Update()
    {
        if (!finished)
        {
            score = FindObjectOfType<ScoreUpdater>().returnScore();
            gameTime += Time.deltaTime;
            minutes = gameTime / 60;
            seconds = gameTime % 60;
            Debug.Log(gameTime + "   minutes " + minutes + "   seconds: " + seconds);
        }

    }

    public void Finish()
    {
        finished = true;
    }
}
