using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject playButton;
    public GameObject exitButton;
    public GameObject controlsButton;
    public GameObject settingsButton;
    public GameObject musicButton;
    public GameObject effectsButton;
    public GameObject returnToMenuButton;
    public GameObject controls;

    private int state = 1;

    void Start() // Turns off the buttons that should initially not be shown.
    {
        musicButton.SetActive(false);
        effectsButton.SetActive(false);
        returnToMenuButton.SetActive(false);
        controls.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    
    /// <summary>
    /// Turns the appropriate buttons (and their children) off or on.
    /// </summary>
    public void ShowControls()
    {
        playButton.SetActive(false);
        exitButton.SetActive(false);
        settingsButton.SetActive(false);
        controls.SetActive(true); // This one in particular will hold all the images that showcase the controls.
        returnToMenuButton.SetActive(true);
        state = 3;
        controlsButton.SetActive(false); // The button should set itself inactive last.
    }

    /// <summary>
    /// Turns the appropriate buttons (and their children) off or on.
    /// </summary>
    public void ShowSettings()
    {
        playButton.SetActive(false);
        exitButton.SetActive(false);
        controlsButton.SetActive(false);
        musicButton.SetActive(true);
        effectsButton.SetActive(true);
        returnToMenuButton.SetActive(true);
        state = 2;
        settingsButton.SetActive(false); // The button should set itself inactive last.
    }

    /// <summary>
    /// Turns the appropriate buttons (and their children) off or on.
    /// </summary>
    public void ReturnToMenu()
    {
        playButton.SetActive(true);
        exitButton.SetActive(true);
        controlsButton.SetActive(true);
        controls.SetActive(false);
        settingsButton.SetActive(true);
        musicButton.SetActive(false);
        effectsButton.SetActive(false);
        state = 1;
        returnToMenuButton.SetActive(false); // The button should set itself inactive last.
    }

    /// <summary>
    /// Advances the sound button of the specified button. 
    /// </summary>
    /// <param name="button"></param>
    public void ChangeSoundVolume(GameObject button)
    {
        SoundButton soundButton = button.GetComponent<SoundButton>();
        soundButton.Advance();
    }

    /// <summary>
    /// The Kinect Menu Script will call this function to press a button, leaving the Menu to figure out which one. It returns true if it pressed a button and false otherwise.
    /// </summary>
    /// <param name="Y"></param>
    public bool PressAButton(float Y)
    {
        switch (state)
        {
            case 1:
                if (InYRange(Y, 4.1f, 2.8f)) // Play
                {
                    PlayGame();
                }
                else if (InYRange(Y, 2.4f, 1.2f)) // Controls
                {
                    ShowControls();
                }
                else if (InYRange(Y, 0.8f, -0.4f)) // Settings
                {
                    ShowSettings();
                }
                else if (InYRange(Y, -0.8f, -2f)) // Exit
                {
                    ExitGame();
                }
                else
                {
                    return false;
                }
                return true;
            case 2:
                if (InYRange(Y, 4.1f, 2.8f)) // Music
                {
                    ChangeSoundVolume(musicButton);
                }
                else if (InYRange(Y, 2.4f, 1.2f)) // Effects
                {
                    ChangeSoundVolume(effectsButton);
                }
                else if (InYRange(Y, 0.8f, -0.4f)) // Menu
                {
                    ReturnToMenu();
                }
                else
                {
                    return false;
                }
                return true;
            case 3:
                if (InYRange(Y, 0.8f, -0.4f)) // Menu
                {
                    ReturnToMenu();
                }
                else
                {
                    return false;
                }
                return true;
            default:
                return false;
        }
    }

    bool InYRange(float Y, float top, float bottom) // Unfortunately it seems the values for top and bottom have to be hardcoded and discovered by hand, which is problematic if one wants to add more buttons
    {
        if ((Y < top) && (Y > bottom))
        {
            return true;
        }
        return false;
    }
}
