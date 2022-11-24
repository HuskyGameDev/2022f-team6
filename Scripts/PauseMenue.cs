using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenue : MonoBehaviour
{
    //These are the canvas objects needed for opening menus, note this script should be placed on an object that ISN'T one of these
    [SerializeField] GameObject pauseCanvas;
    [SerializeField] GameObject optionsCanvas;

    private bool isActive = false;

    private void Update()
    {
        //open or close the pause menu when the escape key is pressed
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isActive = !isActive;
            pauseCanvas.SetActive(isActive);

            //pauses time (note only time scale so non-time dependent things still work, i.e outside update functions)
            if(isActive)
            {
                Time.timeScale = 0;
            } else
            {
                Time.timeScale = 1;
            }
        }
    }

    //resumes the game
    public void Resume()
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    //opens up an options menu
    public void Options()
    {
        pauseCanvas.SetActive(false);
        optionsCanvas.SetActive(true);
    }

    //exits the game (currently no save features)
    public void Quit()
    {
        Application.Quit();
    }
}
