using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public int newspapers;
    public GameObject Newspaper1, Newspaper2, Newspaper3, Newspaper4, Newspaper5;
    // Start is called before the first frame update
    void Start()
    {
        newspapers = 5;
        Newspaper1.SetActive(true);
        Newspaper2.SetActive(true);
        Newspaper3.SetActive(true);
        Newspaper4.SetActive(true);
        Newspaper5.SetActive(true);
    }

    void Update()
    {
        if (newspapers > 5)
            newspapers = 5;

        switch (newspapers)
        {
            case 5:
                Newspaper1.SetActive(true);
                Newspaper2.SetActive(true);
                Newspaper3.SetActive(true);
                Newspaper4.SetActive(true);
                Newspaper5.SetActive(true);
                break;
            case 4:
                Newspaper1.SetActive(true);
                Newspaper2.SetActive(true);
                Newspaper3.SetActive(true);
                Newspaper4.SetActive(true);
                Newspaper5.SetActive(false);
                break;
            case 3:
                Newspaper1.SetActive(true);
                Newspaper2.SetActive(true);
                Newspaper3.SetActive(true);
                Newspaper4.SetActive(false);
                Newspaper5.SetActive(false);
                break;
            case 2:
                Newspaper1.SetActive(true);
                Newspaper2.SetActive(true);
                Newspaper3.SetActive(false);
                Newspaper4.SetActive(false);
                Newspaper5.SetActive(false);
                break;
            case 1:
                Newspaper1.SetActive(true);
                Newspaper2.SetActive(false);
                Newspaper3.SetActive(false);
                Newspaper4.SetActive(false);
                Newspaper5.SetActive(false);
                break;
            default:
                Newspaper1.SetActive(false);
                Newspaper2.SetActive(false);
                Newspaper3.SetActive(false);
                Newspaper4.SetActive(false);
                Newspaper5.SetActive(false);
                break;
        }
    }

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
