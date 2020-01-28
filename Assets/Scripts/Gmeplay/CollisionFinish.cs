using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionFinish : MonoBehaviour
{

    public double timer;
    public bool finished = false;
    public GameObject player;

    void Update()
    {
        if (finished)
        {
            timer += Time.deltaTime;
        }

        if (timer > 5)
        {
            player.GetComponent<ControlledVelocity>().Finish();
            Debug.Log("FINISH");
            SceneManager.LoadScene("Level_1");
        }
    }

    // Als de speler door de finish rijdt, wordt het volgende level geladen. 
    void OnTriggerEnter(Collider otherObj)
    {
        FindObjectOfType<Score>().Finish();
        finished = true;
    }
}