using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(-20 * GetComponent<Variables>().richting, 0, 0);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
}
