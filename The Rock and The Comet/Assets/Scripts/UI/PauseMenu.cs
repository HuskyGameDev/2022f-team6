using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{ 
    //These are the canvas objects needed for opening menus, note this script should be placed on an object that ISN'T one of these
    [SerializeField] GameObject pauseCanvas;
    [SerializeField] GameObject playerUI;
    [SerializeField] GameObject mapMenu;
    [SerializeField] GameObject controlsMenu;

    private bool isActive = false;
    private bool mapActive = false;

    private void Update()
    {
        //open or close the pause menu when the escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isActive = !isActive;

            //open or close the pause menu and player ui
            pauseCanvas.SetActive(isActive);
            playerUI.SetActive(!isActive);

            //always exit other menus
            closeSubMenus();

            //pauses time (note only time scale so non-time dependent things still work, i.e outside update functions)
            if (isActive)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            mapActive = !mapActive;
            mapMenu.SetActive(mapActive);

            //pauses time (note only time scale so non-time dependent things still work, i.e outside update functions)
            if (isActive)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }

    //resumes the game
    public void Resume()
    {
        isActive = false;
        pauseCanvas.SetActive(false);
        playerUI.SetActive(true);
        Time.timeScale = 1;
    }

    public void Controls()
    {
        loadCanvas(controlsMenu);
    }

    //exits the game (currently no save features)
    public void Quit()
    {
        Application.Quit();
    }

    public void Back()
    {
        loadCanvas(pauseCanvas);
    }

    //opens a canvas and closes all others
    private void loadCanvas(GameObject turnOn)
    {
        pauseCanvas.SetActive(false);
        controlsMenu.SetActive(false);

        turnOn.SetActive(true);
    }

    private void closeSubMenus()
    {
        controlsMenu.SetActive(false);
        mapMenu.SetActive(false);
    }
}
