using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionFinish : MonoBehaviour
{

    public double timer;
    public GameObject player;
    public GameObject victory;
    public GameObject playAgain;
    public bool finished = false;

    [SerializeField]
    KeyCode space;

    void Update()
    {
        if (finished)
        {
            if (Input.GetKeyDown(space))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene("Level_1");
            }
        }
    }

    void OnTriggerEnter(Collider otherObj)
            {
                FindObjectOfType<Score>().Finish();
                player.GetComponent<ControlledVelocity>().Finish();
                victory.GetComponent<VictoryScript>().Display("Victory");
                playAgain.GetComponent<VictoryScript>().Display("Press space to play again!");
                finished = true;
                Time.timeScale = 0;
            }
        }