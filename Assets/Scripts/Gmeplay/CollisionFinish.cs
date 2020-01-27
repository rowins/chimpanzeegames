using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionFinish : MonoBehaviour
{
    // Als de speler door de finish rijdt, wordt het volgende level geladen. 
    void OnTriggerEnter(Collider otherObj)
    {
        Debug.Log("FINISH");
        SceneManager.LoadScene("Level_1");
    }
}