using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{

    [SerializeField]
    GameObject wall;

    [SerializeField]
    float maxDistance;

    [SerializeField]
    float newDistance;

    float distX, distZ;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Zorgen dat er een muur achter de speler zit, waardoor de speler niet kan terugfietsen.

        distX = Mathf.Abs(wall.transform.position.x - transform.position.x);
        distZ = Mathf.Abs(wall.transform.position.z - transform.position.z);
        distance = Mathf.Sqrt((distX*distX) + (distZ* distZ));

        if (distance > maxDistance || Input.GetKey(KeyCode.A))
        {
            Vector3 wallPos = new Vector3(-GetComponent<ControlledVelocity>().velX / Time.deltaTime * newDistance, 0, -GetComponent<ControlledVelocity>().velZ / Time.deltaTime * newDistance);
            wall.transform.position = wallPos + transform.position;
            wall.transform.rotation = transform.rotation;
        }
    }
}
