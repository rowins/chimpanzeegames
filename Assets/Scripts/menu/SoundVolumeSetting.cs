using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundVolumeSetting : MonoBehaviour
{
    public AudioSource source;
    public string key;

    void Start()
    {
        if (PlayerPrefs.HasKey(key))
        {
            source.volume = PlayerPrefs.GetFloat(key);
        }
    }

    void Update()
    {
        if (PlayerPrefs.HasKey(key))
        {
            source.volume = PlayerPrefs.GetFloat(key);
        }
    }
}
