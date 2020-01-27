using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gegevens : MonoBehaviour
{
    // Bijhouden of iemand abonnee is en een krant heeft ontvangen.
    public bool isAbonnee;
    public bool krantBezorgd;
    public bool wasAbonnee;

    // Start is called before the first frame update
    void Start()
    {
        isAbonnee = false;
        int IsAbb = Random.Range(1, 4);
        if (IsAbb == 1)
        {
            isAbonnee = true;
        }
        wasAbonnee = isAbonnee;
        krantBezorgd = false;

        if (isAbonnee == true)
        {
            GameObject.Find("Score").GetComponent<Score>().abonnees++;
        }
    }
}
