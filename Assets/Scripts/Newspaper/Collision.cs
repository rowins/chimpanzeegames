using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public int timeOut;
    public GameObject player;
    public GameObject wall;

    void Start()
    {
        Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {
        // Als de krant de speler raakt heeft dit geen invloed op de krant
        Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>());

        // De krant kan door de onzichtbare muur die achter de speler staat
        Physics.IgnoreCollision(GetComponent<Collider>(), wall.GetComponent<Collider>());
    }

}
