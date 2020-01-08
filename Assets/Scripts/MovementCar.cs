using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCar : MonoBehaviour
{
    public float speed;
    public Vector3 location;

    float progress = 0;
    Vector3 direction;

    void Start()
    {
        //Debug.Log("start");
        direction = location / location.magnitude;
    }

    void Update()
    {
        transform.position += speed * direction * Time.deltaTime;
        progress += speed * Time.deltaTime;

        if (progress >= location.magnitude)
        {
            transform.position -= location;
            progress = 0;
        }
    }

}
