using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportMidPointBlue : MonoBehaviour
{
    GameObject greenPortal, bluePortal;
    GameObject portalExitPointBlue;

    Transform blueMidPoint,greenMidPoint;

    public static bool isAtPortalMid = false;
    
    void Start()
    {
        
        if(GameObject.Find("teleportExitPointBlue") != null)
        {

            portalExitPointBlue = GameObject.Find("teleportExitPointBlue");

        }

        if (GameObject.Find("bluePortal") != null)
        {
            bluePortal = GameObject.Find("bluePortal");
            blueMidPoint = bluePortal.transform.GetChild(2);


        }
        if (GameObject.Find("greenPortal") != null)
        {
            greenPortal = GameObject.Find("greenPortal");
            greenMidPoint = greenPortal.transform.GetChild(2);


        }



    }

    
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") && portalTeleportGreen.enteredGreen == false)
        {
            Debug.Log("BLUE TELEPORTED");
            
            

            // adding force depending on the other wall
            if (portalGun.attachedObjGreen != null)
            {
                if (portalGun.attachedObjGreen.name.Equals("leftWall"))
                {
                    
                    collision.transform.position = new Vector2(greenMidPoint.transform.position.x +0.2f, greenMidPoint.transform.position.y);
                    collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(500f, 0f));
                }
                if (portalGun.attachedObjGreen.name.Equals("rightWall"))
                {
                    
                    collision.transform.position = new Vector2(greenMidPoint.transform.position.x -0.2f, greenMidPoint.transform.position.y);
                    collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(-500f, 0f));
                }
                if (portalGun.attachedObjGreen.name.Equals("bottomWall"))
                {
                    collision.transform.position = new Vector2(greenMidPoint.transform.position.x, greenMidPoint.transform.position.y+0.1f);
                    // adding force depending on which wall i entered from
                    if (portalTeleportBlue.blueEnteredWall == "bottomWall")
                    {
                        collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 600f));
                    }
                    if (portalTeleportBlue.blueEnteredWall == "leftWall" || portalTeleportBlue.blueEnteredWall == "rightWall")
                    {
                        collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 200f));
                    }
                }
                if (portalGun.attachedObjGreen.name.Equals("topWall"))
                {
                    collision.transform.position = new Vector2(greenMidPoint.transform.position.x, greenMidPoint.transform.position.y -0.6f);
                    collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -500f));
                }
            }

            // make the character move again

            collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            collision.gameObject.GetComponent<playerMovement>().ableToMove = true;
            collision.gameObject.layer = 2;
            collision.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
            

        }

        ///////------------------------------------------------------FOR PUSHABLE BOX ----------------
        if (collision.tag.Equals("pushableBox") && portalTeleportGreen.enteredGreenForBox == false)
        {

            if (portalGun.attachedObjGreen.name.Equals("bottomWall"))
            {

                collision.transform.position = new Vector2(greenMidPoint.transform.position.x, greenMidPoint.transform.position.y + 0.5f);
                // adding force depending on which wall i entered from
                if (portalTeleportBlue.blueBoxEnteredWall == "bottomWall")
                {
                    Debug.Log("TELEPORTED FROM MIDPOINT BLUE");
                    collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 700f));
                }
                if (portalTeleportBlue.blueBoxEnteredWall == "leftWall" || portalTeleportBlue.blueBoxEnteredWall == "rightWall")
                {
                    Debug.Log("Yawwwasdsadsadasdasdsa");
                    collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 500f));
                }
            }
            if (portalGun.attachedObjGreen.name.Equals("leftWall"))
            {
                
                Debug.Log("leftWALL STATE WORKED");
                collision.transform.position = new Vector2(greenMidPoint.transform.position.x + 0.4f, greenMidPoint.transform.position.y);
                collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(300f, 0f));
            }

            if (portalGun.attachedObjGreen.name.Equals("rightWall"))
            {
                Debug.Log("this workedasdasdasdaassaasdw");
                collision.transform.position = new Vector2(greenMidPoint.transform.position.x - 0.5f, greenMidPoint.transform.position.y);
                collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(-400f, 0f));
            }

            if (portalGun.attachedObjGreen.name.Equals("topWall"))
            {
                collision.transform.position = new Vector2(greenMidPoint.transform.position.x, greenMidPoint.transform.position.y -0.4f );
                collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -500f));
            }

            Debug.Log("lastCond");
            collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            collision.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
            collision.gameObject.layer = 2;


        }


    }
}
