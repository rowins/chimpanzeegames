using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public int timeOut;
    public GameObject player;
    public GameObject wall;

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {
        Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>());
        Physics.IgnoreCollision(GetComponent<Collider>(), wall.GetComponent<Collider>());
    }

    
}
