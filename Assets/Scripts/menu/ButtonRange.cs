using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRange : MonoBehaviour
{
    public GameObject thisButton;
    private float top;
    private float bottom;

    // Start is called before the first frame update
    void Start()
    {
        top = thisButton.transform.position.y + thisButton.transform.lossyScale.y * thisButton.transform.up.y;
        bottom = thisButton.transform.position.y - thisButton.transform.lossyScale.y * thisButton.transform.up.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool InYRange(float Y)
    {
        if (Y < top) // && Y > bottom) // If the second condition is turned on, it will somehow never be true
        {
            return true;
        }
        return false;
    }
}
