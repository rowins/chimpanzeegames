using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlledVelocity : MonoBehaviour
{
    [SerializeField]
    Vector3 Force;

    public float speed;

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
    float maxSpeed;

    // Start is called before the first frame update
    void Awake()
    {
        speed = 0;
        maxSpeed = 900;
        acceleration = 100;
        initialTurnSpeed = 100;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CalculateSpeed();

        turnSpeed = initialTurnSpeed + (speed * 0.01f);

        if (Input.GetKey(keyForward))
        {
            if (speed <= maxSpeed) speed += acceleration * Time.deltaTime;
        }

        if (Input.GetKey(keyBackward))
        {
            if (speed >= 0) speed -= acceleration * 3 * Time.deltaTime;
        }

        if (speed < 0) speed = 0;
        if (speed > maxSpeed) speed = maxSpeed;

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
