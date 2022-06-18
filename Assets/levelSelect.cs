using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelSelect : MonoBehaviour
{
    GameObject pauseCanvas;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // button to replay the tutorial
    public void playTutorialButton()
    {
        checkPointTutorial.latestCheckpointTutorial = null;

        SceneManager.LoadScene(2);
        // if the game was paused , unpause it
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    // button to replay level one
    public void levelOneButton()
    {
        playerCheckpoint.latestCheckpointOne = null;

        if (playerMovement.unlockedOne == true)
        {
            SceneManager.LoadScene(3);
        }
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }



    }

    public void levelTwoButton()
    {
        
        checkPointTwo.latestCheckpointTwo = null;

        if (playerMovement.unlockedTwo == true)
        {
            SceneManager.LoadScene(4);
        }
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        
        /*
        checkPointTwo.latestCheckpointTwo = null;

        if (playerMovement.unlockedTwo == false)
        {
            SceneManager.LoadScene(3);
        }
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        */


    }

    public void levelThreeButton()
    {
        
        checkPointThree.latestCheckpointThree = null;

        if (playerMovement.unlockedThree == true)
        {
            SceneManager.LoadScene(5);
        }
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        

        /*
        checkPointThree.latestCheckpointThree = null;

        if (playerMovement.unlockedThree == false)
        {
            SceneManager.LoadScene(4);
        }
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        */



    }

    public void levelFourButton()
    {


        
        if (playerMovement.unlockedFour == true)
        {
            SceneManager.LoadScene(6);
        }
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        
        /*
        if (playerMovement.unlockedFour == false)
        {
            SceneManager.LoadScene(5);
        }
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        */



    }

    public void levelFiveButton()
    {



        if (playerMovement.unlockedFive == true)
        {
            SceneManager.LoadScene(7);
        }
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }



    }
}
