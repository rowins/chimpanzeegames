using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlledVelocity : MonoBehaviour
{
    [SerializeField]
    Vector3 Force;

    public float speed;
    public float maxSpeed;

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

    public float angleY;
    public float velX, velZ;
    float initialTurnSpeed;
    public Text textDBG;
    public bool inGate;

    void Awake()
    {
        speed = 0;
        maxSpeed = 900;
        acceleration = 100;
        initialTurnSpeed = 100;
        inGate = false;
    }

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

        GetComponent<Rigidbody>().velocity = new Vector3(velX * speed, GetComponent<Rigidbody>().velocity.y - 5, velZ * speed);


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gate") == true)
        {
            if (inGate == false)
            {
                inGate = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Gate") == true)
        {
            if (inGate == true)
            {
                inGate = false;
            }

        }
        if (other.CompareTag("bound") == true && !inGate)
        {
            speed = 0;
        }
    }

    void CalculateSpeed()
    {
        angleY = gameObject.transform.eulerAngles.y * (Mathf.PI / 180);
        velX = Mathf.Sin(angleY) * Time.deltaTime;
        velZ = Mathf.Cos(angleY) * Time.deltaTime;
    }
}