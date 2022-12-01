using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour
{
    //make sure to give this enough scenes for as many buttons as will ever be pressed
    [SerializeField] string[] sceneNames;

    public void lvl1()
    {
        SceneManager.LoadScene(sceneNames[0]);
        Time.timeScale = 1;
    }

    public void lvl2()
    {
        SceneManager.LoadScene(sceneNames[1]);
        Time.timeScale = 1;
    }
}
