using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlledVelocity : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    float acceleration;

    [SerializeField]
    float deceleration;

    [SerializeField]
    float turnSpeed;

    [SerializeField]
    KeyCode keyOne;

    [SerializeField]
    KeyCode keyTwo;

    [SerializeField]
    KeyCode keyThree;

    [SerializeField]
    KeyCode keyFour;

    float angleY;
    float velX;
    float velZ;

    // Update is called once per frame
    void FixedUpdate()
    {
        CalculateSpeed();
        // versnellen
        if (Input.GetKey(keyOne))
        {
            speed += acceleration * Time.deltaTime;
        }

        //remmen
        if (Input.GetKey(keyTwo))
        {
            if (speed >= 0) speed -= deceleration * Time.deltaTime;
        }

        if (speed < 0) speed = 0;

        // naar links draaien
        if (Input.GetKey(keyThree))
        {
            gameObject.transform.eulerAngles -= new Vector3(0, turnSpeed * Time.deltaTime, 0);
        }

        // naar rechts draaien
        if (Input.GetKey(keyFour))
        {
            gameObject.transform.eulerAngles += new Vector3(0, turnSpeed * Time.deltaTime, 0);
        }

        GetComponent<Rigidbody>().velocity = new Vector3(velX, 0, velZ);
    }

    void CalculateSpeed()
    {
        angleY = gameObject.transform.eulerAngles.y * ((float)Math.PI / 180);
        velX = speed * (float)Math.Sin(angleY) * Time.deltaTime;
        velZ = speed * (float)Math.Cos(angleY) * Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(gameObject.transform.position, gameObject.transform.position + new Vector3(velX, 0, velZ));
    }

}
