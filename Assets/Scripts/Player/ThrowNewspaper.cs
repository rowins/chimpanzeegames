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

        if (Input.GetKeyUp(KeyCode.N))
        {
            newspaper.GetComponent<Variables>().richting = 1;
            CalculateVelocity();
            Instantiate(newspaper, new Vector3(transform.position.x, transform.position.y + 1.6F, transform.position.z), Quaternion.identity);
        }

        if (Input.GetKeyUp(KeyCode.M))
        {
            newspaper.GetComponent<Variables>().richting = -1;
            CalculateVelocity();
            Instantiate(newspaper, new Vector3(transform.position.x, transform.position.y + 1.6F, transform.position.z), Quaternion.identity);
        }
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
