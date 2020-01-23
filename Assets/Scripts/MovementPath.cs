using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPath : MonoBehaviour
{
    public float speed;
    public int start;
    public string pathName;

    Vector3 goalLocation;
    float progress = 0;
    Vector3 direction;
    int segment = 0;

    void Start()
    {
        segment = start;
        Arrive(segment);
    }

    void Update()
    {

        if (progress >= goalLocation.magnitude)
        {
            Arrive(segment+1);
            progress = 0;
        }

        transform.position += speed * direction * Time.deltaTime;
        progress += speed * Time.deltaTime;

    }

    void Arrive(int x)
    {
        GameObject move = GameObject.Find("/Environment/Obstacles/" + pathName + "/" + x);

        transform.position = move.transform.position;
        transform.localEulerAngles = move.transform.localEulerAngles;

        GameObject goal = GameObject.Find("/Environment/Obstacles/" + pathName + "/" + (x+1));
        
        segment = x;

        if (goal == null)
        {
            if (x == 0) { return; }

            Arrive(0);
        }
        else
        {
            goalLocation = goal.transform.position - transform.position;
            direction = goalLocation / goalLocation.magnitude;
        }
    }
}
