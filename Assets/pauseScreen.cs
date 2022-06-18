using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseScreen : MonoBehaviour
{
    public static bool isPaused = false;
    public Canvas pauseCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        pauseGame();
        
    }



    public void pauseGame()
    {
        // pausing and unpausing the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == false)
            {
                pauseCanvas.enabled = true;
                Debug.Log("Paused the game");
                Time.timeScale = 0;
                isPaused = true;
            }
            else if(isPaused == true)
            {
                pauseCanvas.enabled = false;
                Debug.Log("Resumed the game");
                Time.timeScale = 1;
                isPaused = false;
            }

        }
        
        
    }
}
