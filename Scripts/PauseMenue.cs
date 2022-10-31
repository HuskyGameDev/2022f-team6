using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenue : MonoBehaviour
{
    [SerializeField] GameObject pauseCanvas;
    [SerializeField] GameObject optionsCanvas;

    private bool isActive = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isActive = !isActive;
            pauseCanvas.SetActive(isActive);
        }
    }

    public void Resume()
    {
        pauseCanvas.SetActive(false);
    }

    public void Options()
    {
        pauseCanvas.SetActive(false);
        optionsCanvas.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
