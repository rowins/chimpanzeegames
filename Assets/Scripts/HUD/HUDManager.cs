using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDManager : MonoBehaviour
{
    public int newspapers;

    public bool newsPaperCheck()
    {
        if(newspapers > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void thrown()
    {
        newspapers--;
    }
}
