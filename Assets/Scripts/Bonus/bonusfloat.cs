using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonusfloat : MonoBehaviour
{
    private Vector3 startPosition;
    bool up = true;

    void Start()
    {
        startPosition = transform.position;
    }
    
    void Update()
    {
        MoveVertical();
    }

    void MoveVertical()
    {
        var temp = transform.position;
        if (up == true)
        {
            temp.y += 0.015f;
            transform.position = temp;
            if (transform.position.y >= startPosition.y + 0.6f)
            {
                up = false;
            }
        }
        if (up == false)
        {
            temp.y -= 0.015f;
            transform.position = temp;
            if (transform.position.y <= startPosition.y - 0.6f)
            {
                up = true;
            }
        }
    }
}
