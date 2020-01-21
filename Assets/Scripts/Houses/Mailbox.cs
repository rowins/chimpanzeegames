﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mailbox : MonoBehaviour
{
    public AudioClip impact;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider otherObj)
    {
        // Bij het ontvangen van een krant, actie ondernemen
        if (otherObj.gameObject.tag == "newspaper")
        {
            if (GetComponentInParent<Gegevens>().isAbonnee == true && GetComponentInParent<Gegevens>().krantBezorgd == false)
            {
                FindObjectOfType<ScoreUpdater>().addScore();
                audioSource.PlayOneShot(impact, 0.7F);
                GetComponentInParent<Gegevens>().krantBezorgd = true;
                GameObject.Find("Score").GetComponent<Score>().score += 50;
                Destroy(otherObj.gameObject);
            }
        }
    }
}
