using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VictoryScript : MonoBehaviour
{
    public TextMeshProUGUI Text;

    void Start()
    {
        Text = GetComponent<TextMeshProUGUI>();
        
    }
    public void Display(string msg)
    {
        Text.text = msg;
    }
}
