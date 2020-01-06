using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    void OnCollisionEnter(UnityEngine.Collision other)
    {
        Debug.Log("finish");

        if (other.gameObject.tag == "finish")
        {
            Debug.Log("finish");
        }
    }
}
