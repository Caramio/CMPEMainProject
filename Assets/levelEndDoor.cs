using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelEndDoor : MonoBehaviour
{
    bool canGoNextLevelOne = false;
    bool canGoNextLevelTwo = false;
    bool canGoNextLevelThree = false;
    bool canGoNextLevelFour = false;
    bool canGoNextLevelFive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if cangonext level is true i can load the next level
        if (Input.GetKeyDown("e"))
        {
            // load the next level
            if (canGoNextLevelOne == true)
            {
                SceneManager.LoadScene(3);            
                canGoNextLevelOne = false;
            }

            if(canGoNextLevelTwo == true)
            {
                SceneManager.LoadScene(4);
                canGoNextLevelTwo = false;
            }
            if (canGoNextLevelThree)
            {
                SceneManager.LoadScene(5);
                canGoNextLevelThree = false;
            }
            if (canGoNextLevelFour)
            {
                SceneManager.LoadScene(6);
                canGoNextLevelFour = false;
            }
            if (canGoNextLevelFive)
            {
                SceneManager.LoadScene(7);
                canGoNextLevelFive = false;
            }
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
            if (collision.tag.Equals("Player"))
            {
                if (this.name.Equals("levelOneDoor"))
                {
                canGoNextLevelOne = true;
                }

            if (this.name.Equals("levelTwoDoor"))
            {
                canGoNextLevelTwo = true;
            }

            if (this.name.Equals("levelThreeDoor"))
            {
                canGoNextLevelThree = true;
            }

            if (this.name.Equals("levelFourDoor"))
            {
                canGoNextLevelFour = true;
            }
            if (this.name.Equals("levelFiveDoor"))
            {

                canGoNextLevelFive = true;
            }


        }      
    }

    private void OnTriggerExit2D(Collider2D collision)
    {


        if (collision.tag.Equals("Player"))
        {
            if (this.name.Equals("levelOneDoor"))
            {
                canGoNextLevelOne = false;
            }

            if (this.name.Equals("levelTwoDoor"))
            {
                canGoNextLevelTwo = false;
            }
            if (this.name.Equals("levelThreeDoor"))
            {
                canGoNextLevelThree = false;
            }
            if (this.name.Equals("levelThreeDoor"))
            {
                canGoNextLevelFour = false;
            }
            if (this.name.Equals("levelFiveDoor"))
            {
                canGoNextLevelFive = false;
            }


        }
    }
}
