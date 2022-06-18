using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableMotionBlue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            // setting to false so i can portal through blue now...
            portalTeleportGreen.enteredGreen = false;

            collision.GetComponent<playerMovement>().ableToMove = true;
            collision.gameObject.layer = 2;
            collision.GetComponent<SpriteRenderer>().sortingLayerName = "Default";

            Debug.Log("Enabled blue motion : Entered green var : " + portalTeleportGreen.enteredGreen);

        }

        if (collision.tag.Equals("pushableBox"))
        {
            portalTeleportGreen.enteredGreenForBox = false;
            collision.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            
            collision.gameObject.layer = 2;
            collision.GetComponent<SpriteRenderer>().sortingLayerName = "Default";

            

        }
    }
}
