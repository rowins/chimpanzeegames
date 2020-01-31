using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSound : MonoBehaviour
{
    public AudioSource[] AudioClips = null;
    AudioSource bonusSound;

    void Start()
    {
        bonusSound = GetComponent<AudioSource>();
    }

    public void playSound(int x)
    {

        switch (x)
        {
            case 1:
                AudioClips[0].Play();
                break;
            case 2:
                AudioClips[1].Play();
                break;
            default:
                AudioClips[0].Play();
                break;
        }

    }
}
