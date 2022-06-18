using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startScreenHolder : MonoBehaviour
{

    public static Sprite charSprite;

    public Sprite greySprite;
    public Sprite brownSprite;

    public static Color selectedColor;

    public Canvas charSelectCanvas;
    public Canvas startCanvas;

    public static bool colorSelected = false;

    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void startGame()
    {

        SceneManager.LoadScene(2);

       

    }

    public void characterSelectGrey()
    {


        charSprite = greySprite;
        selectedColor = Color.grey;

        colorSelected = true;



    }


    public void characterSelectBrown()
    {

        charSprite = brownSprite;
        selectedColor = new Color(1, 0.4852941f, 0);

        colorSelected = true;


    }

    public void characterSelect()
    {
        startCanvas.enabled = false;
        charSelectCanvas.enabled = true;
    }


    public void okButton()
    {
        charSelectCanvas.enabled = false;
        startCanvas.enabled = true;

    }

    public void exitButton()
    {
        Application.Quit();
    }


}
