using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_player : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("finish");

        if (other.gameObject.tag == "finish")
        {
            Debug.Log("finish");
        }
    }
}
