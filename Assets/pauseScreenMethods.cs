using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseScreenMethods : MonoBehaviour
{
    public Canvas pauseCanvas;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void resumeGame()
    {

        Time.timeScale = 1;
        pauseCanvas.enabled = false;
        pauseScreen.isPaused = false;


    }


    public void levelSelect()
    {
        SceneManager.LoadScene(1);
        pauseCanvas.enabled = false;
        pauseScreen.isPaused = false;
    }
}
