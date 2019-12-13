using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowNewspaper : MonoBehaviour
{
    public GameObject newspaper;

    [SerializeField]
    float speed;

    public Vector3 velocity;
    float angleY, velX, velZ;

    void Start()
    {
        speed = 10000;
    }

    void Update()
    {
        // Krant naar links laten gooien
        if (Input.GetKeyUp(KeyCode.N))
        {
            if (FindObjectOfType<HUDManager>().newsPaperCheck())
            {
                CreateNewspaper(-1);
                /* FindObjectOfType<HUDManager>().thrown();
                newspaper.GetComponent<Variables>().richting = -1;
                CalculateVelocity();
                Instantiate(newspaper, new Vector3(transform.position.x, transform.position.y + 1.6F, transform.position.z), Quaternion.identity); */
            }
        }

        // Krant naar rechts laten gooien
        if (Input.GetKeyUp(KeyCode.M))
        {
            if (FindObjectOfType<HUDManager>().newsPaperCheck())
            {
                CreateNewspaper(1);
                /*FindObjectOfType<HUDManager>().thrown();
                newspaper.GetComponent<Variables>().richting = 1;
                CalculateVelocity();
                Instantiate(newspaper, new Vector3(transform.position.x, transform.position.y + 1.6F, transform.position.z), Quaternion.identity);*/
            }
        }
    }

    /// <summary>
    /// A public method to throw a newspaper (for the Kinect Controller to call)
    /// </summary>
    /// <param name="richting">-1 is to the left, 1 is to the right</param>
    public void CreateNewspaper(int richting)
    {
        if (FindObjectOfType<HUDManager>().newsPaperCheck())
        {
            FindObjectOfType<HUDManager>().thrown();
            newspaper.GetComponent<Variables>().richting = richting;
            CalculateVelocity();
            Instantiate(newspaper, new Vector3(transform.position.x, transform.position.y + 1.6F, transform.position.z), Quaternion.identity);
        }
    }

    /// <summary>
    /// A public method to throw a newspaper (for the Kinect Controller to call)
    /// </summary>
    /// <param name="richting">-1 is to the left, 1 is to the right</param>
    public void CreateNewspaper(int richting)
    {
        newspaper.GetComponent<Variables>().richting = richting;
        CalculateVelocity();
        Instantiate(newspaper, new Vector3(transform.position.x, transform.position.y + 1.6F, transform.position.z), Quaternion.identity);
    }

    void CalculateVelocity()
    {
        if (newspaper.GetComponent<Variables>().richting == 1)
        {
            velX = -GetComponent<ControlledVelocity>().velZ * speed;
            velZ = GetComponent<ControlledVelocity>().velX * speed;
        }

        if (newspaper.GetComponent<Variables>().richting == -1)
        {
            velX = GetComponent<ControlledVelocity>().velZ * speed;
            velZ = -GetComponent<ControlledVelocity>().velX * speed;
        }

        velocity = new Vector3(velX * Time.deltaTime, 0, velZ * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + velocity);
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == "newspaper")
        {
            Physics.IgnoreCollision(newspaper.GetComponent<BoxCollider>(), GetComponent<BoxCollider>());
        }
    }
}
