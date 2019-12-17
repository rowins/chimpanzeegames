using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColorMailBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // De kleur van de brievenbus bepalen of een klant een krant wilt.
        if (GetComponentInParent<Gegevens>().isAbonnee == true)
        {
            if (GetComponentInParent<Gegevens>().krantBezorgd == false)
            {
                gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
            }
            else
            {
                gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.grey);
            }
            
        }
        else if (GetComponentInParent<Gegevens>().isAbonnee == false)
        {
            gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
        }
    }
}
