using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BonusCollision : MonoBehaviour
{
    AudioSource bonusSound;

    void Start()
    {
        bonusSound = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider other)
    {
        

        if (other.CompareTag("Player") == true)
        {
            

            if (name == "Diamond")
            {
                FindObjectOfType<BonusSound>().playSound(2);
                FindObjectOfType<ScoreUpdater>().addScore(200);
            }
            else if (name == "Paper")
            {
                FindObjectOfType<BonusSound>().playSound(1);
                FindObjectOfType<HUDManager>().addNewspapers(2);
            }
            Destroy(gameObject);
        }

    }


}
