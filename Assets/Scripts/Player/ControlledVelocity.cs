using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlledVelocity : MonoBehaviour
{
    [SerializeField]
    Vector3 Force;

    public float speed;
    public float minSpeed;
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
        speed = 600;
        minSpeed = 600;
        maxSpeed = 1500;
        acceleration = 150;
        initialTurnSpeed = 100;
        inGate = false;
    }

    void FixedUpdate()
    {
        CalculateSpeed();
        turnSpeed = initialTurnSpeed + (speed * 0.01f);

        // Input van de toetsen registeren en acties erop uitvoeren..

        if (Input.GetKey(keyForward))
        {
            Accelerate();
            //if (speed <= maxSpeed) speed += acceleration * Time.deltaTime; // De velocity steeds verhogen
        }

        if (Input.GetKey(keyBackward))
        {
            Decelerate();
            //if (speed >= 0) speed -= acceleration * 3 * Time.deltaTime;
        }

        //if (speed < 0) speed = 0;
        //if (speed > maxSpeed) speed = maxSpeed;

        // Hieronder de speler roteren

        if (Input.GetKey(keyLeft))
        {
            Turn(-1);
            //gameObject.transform.eulerAngles -= new Vector3(0, turnSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKey(keyRight))
        {
            Turn(1);
            //gameObject.transform.eulerAngles += new Vector3(0, turnSpeed * Time.deltaTime, 0);
        }

        GetComponent<Rigidbody>().velocity = new Vector3(velX * speed, GetComponent<Rigidbody>().velocity.y - 5, velZ * speed);


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gate") == true) // De speler tussen verschillende delen van de weg kunnen laten rijden
        {
            if (inGate == false)
            {
                inGate = true;
            }
        }
    }

    /// <summary>
    /// Zorgen dat de speler niet van de weg af kan rijden
    /// </summary>
    /// <param name="other"></param>
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
    
    /// <summary>
    /// De speler onder de goede hoek laten fietsen.
    /// </summary>
    void CalculateSpeed()
    {
        angleY = gameObject.transform.eulerAngles.y * (Mathf.PI / 180);
        velX = Mathf.Sin(angleY) * Time.deltaTime;
        velZ = Mathf.Cos(angleY) * Time.deltaTime;
    }

    /// <summary>
    /// A public method to accelerate (for the Kinect Controller to call)
    /// </summary>
    public void Accelerate()
    {
        if (speed <= maxSpeed) speed += acceleration * Time.deltaTime;
        if (speed > maxSpeed) speed = maxSpeed;
    }

    /// <summary>
    /// A public method to decelerate (for the Kinect Controller to call)
    /// </summary>
    public void Decelerate()
    {
        if (speed >= 0) speed -= acceleration * 3 * Time.deltaTime;
        if (speed < 0) speed = minSpeed;
    }

    /// <summary>
    /// A public method to turn the bike (for the Kinect Controller to call)
    /// </summary>
    /// <param name="direction">-1 is to the left, 1 is to the right</param>
    public void Turn(int direction)
    {
        gameObject.transform.eulerAngles += new Vector3(0, turnSpeed * Time.deltaTime, 0) * direction;
    }
}