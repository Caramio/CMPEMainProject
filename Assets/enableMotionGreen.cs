using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableMotionGreen : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            portalTeleportBlue.enteredBlue = false;

            collision.GetComponent<playerMovement>().ableToMove = true;
            collision.gameObject.layer = 2;
            collision.GetComponent<SpriteRenderer>().sortingLayerName = "Default";

        }

        if (collision.tag.Equals("pushableBox"))
        {
            portalTeleportBlue.enteredBlueForBox = false;
            collision.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            
            collision.gameObject.layer = 2;
            collision.GetComponent<SpriteRenderer>().sortingLayerName = "Default";

            
        }
    }
}
