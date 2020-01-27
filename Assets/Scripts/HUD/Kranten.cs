using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Kranten : MonoBehaviour
{
    public TextMeshProUGUI kranten;

    public GameObject HUD;

    public 

    // Start is called before the first frame update
    void Start()
    {
        kranten = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        kranten.text = HUD.GetComponent<HUDManager>().newspapers.ToString();
    }
}
