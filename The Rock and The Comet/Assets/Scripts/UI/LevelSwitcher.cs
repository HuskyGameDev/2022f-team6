using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour
{ 

    public void levelSwitch(Collider2D collision)
    {
        string name = collision.gameObject.name;
        switch (name)
        {
            case "Crystal Caves Entry 1":
                crystalCaves();
                break;
            case "Crystal Caves Entry 2":
                crystalCaves();
                break;
            case "Caves 2 Entry":
                caves2();
                break;
            case "Caves 1 Entry 1":
                caves1();
                break;
            case "Caves 1 Entry 2":
                caves1();
                break;
            case "Caves 1 Entry":
                caves1();
                break;
            case "Caves 1 From Surface":
                caves1();
                break;
            case "Caves 2 From Surface":
                caves2();
                break;
        }
    }

    public void surfaceLevel()
    {
        SceneManager.LoadScene("Surface Level");
        Time.timeScale = 1;
    }

    public void caves1()
    {
        SceneManager.LoadScene("Caves 1 Level");
        Time.timeScale = 1;
    }

    public void caves2()
    {
        SceneManager.LoadScene("Caves 2 Level");
        Time.timeScale = 1;
    }

    public void crystalCaves()
    {
        SceneManager.LoadScene("Crystal Cave Level");
        Time.timeScale = 1;

    }
}
