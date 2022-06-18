using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelButtonAppearance : MonoBehaviour
{
    

    public GameObject thisButton;
    bool unlockedLevelOne = false , unlockedLevelTwo = false , unlockedLevelThree = false , unlockedLevelFour = false , unlockedLevelFive = false;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.name.Equals("LevelOneInfo"))
        {
            levelOneUnlock();
        }
        if (this.name.Equals("LevelTwoInfo"))
        {
            levelTwoUnlock();
        }
        if (this.name.Equals("LevelThreeInfo"))
        {
            levelThreeUnlock();
        }
        if (this.name.Equals("LevelFourInfo"))
        {
            levelFourUnlock();
        }
        if (this.name.Equals("LevelFiveInfo"))
        {
            levelFiveUnlock();
        }

    }



    public void levelOneUnlock()
    {
        if(playerMovement.unlockedOne == true && unlockedLevelOne == false)
        {
            thisButton.transform.GetComponent<UnityEngine.UI.Image>().color = Color.green;
            this.GetComponent<TMPro.TextMeshProUGUI>().text = "A way out";

            unlockedLevelOne = true;
        }

    }

    public void levelTwoUnlock()
    {
        if (playerMovement.unlockedTwo == true && unlockedLevelTwo == false)
        {
            thisButton.transform.GetComponent<UnityEngine.UI.Image>().color = Color.green;
            this.GetComponent<TMPro.TextMeshProUGUI>().text = "Dark Dungeon";

            unlockedLevelTwo = true;
        }

    }

    public void levelThreeUnlock()
    {
        if (playerMovement.unlockedThree == true && unlockedLevelThree == false)
        {
            thisButton.transform.GetComponent<UnityEngine.UI.Image>().color = Color.green;
            this.GetComponent<TMPro.TextMeshProUGUI>().text = "Red Keep";

            unlockedLevelThree = true;
        }

    }

    public void levelFourUnlock()
    {
        if (playerMovement.unlockedFour == true && unlockedLevelFour == false)
        {
            thisButton.transform.GetComponent<UnityEngine.UI.Image>().color = Color.green;
            this.GetComponent<TMPro.TextMeshProUGUI>().text = "Sewers";

            unlockedLevelFour = true;
        }

    }

    public void levelFiveUnlock()
    {
        if (playerMovement.unlockedFive == true && unlockedLevelFive == false)
        {
            thisButton.transform.GetComponent<UnityEngine.UI.Image>().color = Color.green;
            this.GetComponent<TMPro.TextMeshProUGUI>().text = "Free at last ???";

            unlockedLevelFive = true;
        }

    }



}
