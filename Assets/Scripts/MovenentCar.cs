using System;
using System.Collections.Generic;
using UnityEngine;

public class MovenentCar : MonoBehaviour
{
    public float speed;
    public float distance;

    float progress = 0;

    void Update()
    {

        transform.position += new Vector3(0, 0, speed * Time.deltaTime);
        progress += speed * Time.deltaTime;

        if (Math.Abs(progress) >= Math.Abs(distance))
        {
            transform.position -= new Vector3(0, 0, distance);
            progress -= distance;
        }
    }
}
