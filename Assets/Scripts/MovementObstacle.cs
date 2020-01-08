using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementObstacle : MonoBehaviour
{
    public float speed;
    public Vector3 location;

    float progress = 0;
    Vector3 direction;
    bool forward = true;

    void start()
    {
        //Debug.Log("start");
        direction = location / location.magnitude;
    }

    void Update()
    {
        if (forward)
        {
            transform.position += speed * direction * Time.deltaTime;
            progress += speed * Time.deltaTime;
        }
        else
        {
            transform.position -= speed * direction * Time.deltaTime;
            progress -= speed * Time.deltaTime;
        }

        if (progress >= location.magnitude) forward = false;
        else if (progress <= 0) forward = true;

    }

}
