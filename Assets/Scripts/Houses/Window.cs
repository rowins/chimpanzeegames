using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    bool breaked;

    public AudioClip impact;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        breaked = false;
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider otherObj)
    {
        // Als een krant door een raam wordt gegooid.
        if (otherObj.gameObject.tag == "newspaper")
        {
            if (breaked == false)
            {
                BreakWindow();
            }
        }
    }

    void BreakWindow()
    {
        audioSource.PlayOneShot(impact, 0.7F);

        if (GetComponentInParent<Gegevens>().isAbonnee == true && GetComponentInParent<Gegevens>().krantBezorgd == false)
        {
            // De speler raakt een abonnee kwijt
            GetComponentInParent<Gegevens>().isAbonnee = false;
            GetComponentInParent<Gegevens>().krantBezorgd = true;
            GameObject.Find("Score").GetComponent<Score>().abonnees--;
        }
        else if (GetComponentInParent<Gegevens>().krantBezorgd == false && GetComponentInParent<Gegevens>().wasAbonnee == false)
        {
            // De speler krijgt bonuspunten
            GetComponentInParent<Gegevens>().krantBezorgd = true;
        }
    }
}
