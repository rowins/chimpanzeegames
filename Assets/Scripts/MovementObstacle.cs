using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementObstacle : MonoBehaviour
{
    public float speed;
    public float distance;

    bool forward = true;
    float progress = 0;

    void start()
    {
        if (distance < 0) distance = -distance;
    }

    void Update()
    {
        if (forward)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            progress += speed * Time.deltaTime;
        }
        else
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            progress -= speed * Time.deltaTime;
        }

        if (progress >= distance) forward = false;
        else if (progress <= 0) forward = true;

    }
}