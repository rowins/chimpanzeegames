using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    public string key; // The volume key. This allows different volumes for, for example, effects or music.
    private float volume = 1f;

    public GameObject soundBlock1, soundBlock2, soundBlock3, soundBlock4;

    void Start()
    {
        if (PlayerPrefs.HasKey(key))
        {
            volume = PlayerPrefs.GetFloat(key);
        }
        PlayerPrefs.SetFloat(key, volume); // Sets the default value into PlayerPrefs if none existed before.
        UpdateSoundBlocks();
    }

    /// <summary>
    /// Advances the volume to the next setting, either lowered by 0.25 or turned on fully again. This button model works better for the Kinect than a slider.
    /// </summary>
    public void Advance()
    {
        if (volume == 0)
        {
            volume = 1;
        }
        else
        {
            volume -= 0.25f;
        }
        PlayerPrefs.SetFloat(key, volume); // Saves the new value of the volume in PlayerPrefs, allowing other objects to read it.
        UpdateSoundBlocks();
    }
    
    /// <summary>
    /// This changes the hues of the sound blocks to show the current volume level.
    /// </summary>
    void UpdateSoundBlocks()
    {
        Image sprite1 = soundBlock1.GetComponent<Image>();
        Image sprite2 = soundBlock2.GetComponent<Image>();
        Image sprite3 = soundBlock3.GetComponent<Image>();
        Image sprite4 = soundBlock4.GetComponent<Image>();
        switch (volume)
        {
            case 0:
                sprite1.color = new Color(0.5f, 0.5f, 0.5f);
                sprite2.color = new Color(0.5f, 0.5f, 0.5f);
                sprite3.color = new Color(0.5f, 0.5f, 0.5f);
                sprite4.color = new Color(0.5f, 0.5f, 0.5f);
                break;
            case 0.25f:
                sprite1.color = new Color(1, 1, 1);
                sprite2.color = new Color(0.5f, 0.5f, 0.5f);
                sprite3.color = new Color(0.5f, 0.5f, 0.5f);
                sprite4.color = new Color(0.5f, 0.5f, 0.5f);
                break;
            case 0.5f:
                sprite1.color = new Color(1, 1, 1);
                sprite2.color = new Color(1, 1, 1);
                sprite3.color = new Color(0.5f, 0.5f, 0.5f);
                sprite4.color = new Color(0.5f, 0.5f, 0.5f);
                break;
            case 0.75f:
                sprite1.color = new Color(1, 1, 1);
                sprite2.color = new Color(1, 1, 1);
                sprite3.color = new Color(1, 1, 1);
                sprite4.color = new Color(0.5f, 0.5f, 0.5f);
                break;
            case 1:
                sprite1.color = new Color(1, 1, 1);
                sprite2.color = new Color(1, 1, 1);
                sprite3.color = new Color(1, 1, 1);
                sprite4.color = new Color(1, 1, 1);
                break;
            default:
                break;
        }
    }
}
