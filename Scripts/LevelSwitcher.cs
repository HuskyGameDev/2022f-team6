using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour
{
    [SerializeField] string[] sceneNames;

    //contains the methods to load scenes, attach them to buttons in the editor

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
