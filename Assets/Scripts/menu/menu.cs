﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
   public void PlayGame()
    {
        Debug.Log(1);
        SceneManager.LoadScene("monday-1");
    }

    public void ExitGame()
    {
        Debug.Log(1);
        Application.Quit();
    }
}