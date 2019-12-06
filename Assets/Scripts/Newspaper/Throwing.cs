using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwing : MonoBehaviour
{
    public GameObject player;
    
    void Start()
    {
        GetComponent<Rigidbody>().velocity = player.GetComponent<ThrowNewspaper>().velocity;
    }
}
