using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlledVelocity : MonoBehaviour
{
    [SerializeField]
    Vector3 Force;

    [SerializeField]
    KeyCode keyOne;

    [SerializeField]
    KeyCode keyTwo;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(keyOne))
        {
            GetComponent<Rigidbody>().velocity += Force;
        }
        if (Input.GetKey(keyTwo))
        {
            GetComponent<Rigidbody>().velocity -= Force;
        }

    }
}
