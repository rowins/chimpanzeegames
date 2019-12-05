using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlledVelocity : MonoBehaviour
{
    [SerializeField]
    Vector3 Force;

    [SerializeField]
    float speed;

    [SerializeField]
    float acceleration;

    [SerializeField]
    float turnSpeed;

    [SerializeField]
    KeyCode keyForward;

    [SerializeField]
    KeyCode keyBackward;

    [SerializeField]
    KeyCode keyLeft;

    [SerializeField]
    KeyCode keyRight;

    float angleY;
    float velX, velY;
    float initialTurnSpeed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0;
        acceleration = 500;
        initialTurnSpeed = 75;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CalculateSpeed();

        turnSpeed = initialTurnSpeed + (speed * 0.01f);

        if (Input.GetKey(keyForward))
        {
            speed += acceleration * Time.deltaTime;
        }

        if (Input.GetKey(keyBackward))
        {
            if (speed >= 0) speed -= acceleration * 5 * Time.deltaTime;
        }

        if (speed < 0) speed = 0;

        if (Input.GetKey(keyLeft))
        {
            gameObject.transform.eulerAngles -= new Vector3(0, turnSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKey(keyRight))
        {
            gameObject.transform.eulerAngles += new Vector3(0, turnSpeed * Time.deltaTime, 0);
        }

        GetComponent<Rigidbody>().velocity = new Vector3(velX, 0, velY);
    }

    void CalculateSpeed()
    {
        angleY = gameObject.transform.eulerAngles.y * (Mathf.PI / 180);
        velX = speed * Mathf.Sin(angleY) * Time.deltaTime;
        velY = speed * Mathf.Cos(angleY) * Time.deltaTime;
    }

}
