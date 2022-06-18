using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloneObj : MonoBehaviour
{
    public GameObject clonePoint;

    public float cloneLimit;
    int cloneCounter = 0;

    bool cloneChecker = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cloneCounter - 1 == cloneLimit)
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("pushableBox"))
        {
            if (cloneChecker == false && cloneCounter <= cloneLimit && dragScript.objCurrentCarry == false)
            {
                Instantiate(collision,new Vector2(clonePoint.transform.position.x , clonePoint.transform.position.y + 0.2f), collision.transform.rotation);               
                cloneCounter += 1;
                cloneChecker = true;
            }

        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag.Equals("pushableBox"))
        {
           
                cloneChecker = false;
            
        }
    }
}
