using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDManager : MonoBehaviour
{
    public int newspapers;
    public int maximum = 10;

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

    public void addNewspapers(int x)
    {
        newspapers += x;
        if (newspapers > maximum)
        {
            newspapers = maximum;
        }
    }
}
