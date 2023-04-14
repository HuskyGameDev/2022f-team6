using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour
{ 

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
        SceneManager.LoadScene("Crystal Caves Level");
    }
}
