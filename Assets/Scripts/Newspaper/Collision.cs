using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{

    [SerializeField]
    GameObject wall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider otherObj)
    {
        if (otherObj.gameObject.tag == "window")
        {
            Destroy(this.gameObject);
            Debug.Log(1);
        }

        if (otherObj.gameObject.tag == "bound")
        {
            Physics.IgnoreCollision(wall.GetComponent<BoxCollider>(), GetComponent<BoxCollider>());
        }
    }
}
