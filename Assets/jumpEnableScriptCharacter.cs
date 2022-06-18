using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpEnableScriptCharacter : MonoBehaviour
{

    GameObject astroBuddy;
    void Start()
    {
        if (GameObject.Find("AstroStay") != null)
        {
            astroBuddy = GameObject.Find("AstroStay");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if i land on ground , i can jump again , using a empty script to evaluate this
        if (collision.GetComponent<jumpEnabler>() != null)
        {
            
           playerMovement.canJump = true;
        }

      
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<jumpEnabler>() != null)
        {
            
            playerMovement.canJump = true;
        }
    }

}
