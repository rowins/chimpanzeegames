using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowNewspaper : MonoBehaviour
{
    public GameObject newspaper;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.N))
        {
            Instantiate(newspaper, new Vector3(transform.position.x -1.2f, transform.position.y + 1.8F, transform.position.z), Quaternion.identity);
            newspaper.GetComponent<Variables>().richting = 1;
        }
        if (Input.GetKeyUp(KeyCode.M))
        {
            Instantiate(newspaper, new Vector3(transform.position.x + 2f, transform.position.y + 1.8F, transform.position.z), Quaternion.identity);
            newspaper.GetComponent<Variables>().richting = -1;
        }
    }
}
