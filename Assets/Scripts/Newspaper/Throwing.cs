using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwing : MonoBehaviour
{
    public GameObject player;
    float velX, velZ;

    void Start()
    {

        // De krant onder de goede richting / hoek gooien
        player = GameObject.Find("Player");
        velX = Mathf.Sin(player.GetComponent<ControlledVelocity>().angleY + 90 * (Mathf.PI / 180)) * Time.deltaTime;
        velZ = Mathf.Cos(player.GetComponent<ControlledVelocity>().angleY + 90 * (Mathf.PI / 180)) * Time.deltaTime;
        float rigg = GetComponent<Variables>().richting;
        player = GameObject.Find("Player");
        Debug.Log(player.GetComponent<ControlledVelocity>().velX);
        Debug.Log(player.GetComponent<ControlledVelocity>().velZ);
        GetComponent<Rigidbody>().velocity = new Vector3(velX * 1000 * rigg, 0, velZ * 1000 * rigg);

    }
}
