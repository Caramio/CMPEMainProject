using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalTeleportBlue : MonoBehaviour
{

    //test object
    GameObject testObj;

    // green and blue portals
    GameObject bluePortal;
    GameObject greenPortal;

    // string to see which wall i entered from
    public static string blueEnteredWall;

    // portal midpoints
    Transform blueMidPoint, greenMidPoint;

    //bool for inside portal
    public static bool enteredBlue = false;
    // for box
    public static string blueBoxEnteredWall;

    //bool for inside portal for BOX
    public static bool enteredBlueForBox = false;

    void Start()
    {
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
       // Debug.Log("portal tele blue entered" +portalTeleportBlue.enteredBlue);
       // Debug.Log("portal tele green entered" +portalTeleportGreen.enteredGreen);
        



    }

    // method that teleports objects within the portal
    public void teleportObject()
    {
       
        


        




    }

    // inbetween checker
    public bool inBetween(float maxDifference, float first, float second)
    {
        if (Mathf.Abs(first - second) >= maxDifference)
        {
            return false;

        }
        else
        {
            return true;
        }


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag.Equals("Player") && greenPortal.GetComponent<SpriteRenderer>().enabled == true && portalTeleportGreen.enteredGreen == false)
        {
            // putting velocity to 0 each time i enter a portal
            enteredBlue = true;
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.GetComponent<Rigidbody2D>().transform.position = blueMidPoint.transform.position;
            // if im teleporting from a left wall
            if (portalGun.attachedObjBlue.name.Equals("leftWall")) {
                blueEnteredWall = "leftWall";

                collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(-300f, 0f));

                // restricting player movement while teleporting
                collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
                collision.gameObject.GetComponent<playerMovement>().ableToMove = false;

                collision.gameObject.layer = 8;
                collision.GetComponent<SpriteRenderer>().sortingLayerName = "Teleporting";

                



                Debug.Log("Teleporting");

                //collision.transform.position = new Vector2(greenPortal.transform.position.x, greenPortal.transform.position.y + 2f);

            }

            if (portalGun.attachedObjBlue.name.Equals("bottomWall"))
            {
                blueEnteredWall = "bottomWall";

                collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -300f));

                Debug.Log("TOUCHED BLUE ENTRANCE");

                collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
                collision.gameObject.GetComponent<playerMovement>().ableToMove = false;
                collision.gameObject.layer = 8;
                collision.GetComponent<SpriteRenderer>().sortingLayerName = "Teleporting";
                
              

            }

            if (portalGun.attachedObjBlue.name.Equals("rightWall"))
            {
                blueEnteredWall = "rightWall";
                collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(300f, 0f));

                Debug.Log("TOUCHED BLUE ENTRANCE");
                
                collision.gameObject.GetComponent<playerMovement>().ableToMove = false;
                collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
                collision.gameObject.layer = 8;
                collision.GetComponent<SpriteRenderer>().sortingLayerName = "Teleporting";



            }
            if (portalGun.attachedObjBlue.name.Equals("topWall"))
            {
                blueEnteredWall = "topWall";

                Debug.Log("TOUCHED GREEN ENTRANCE");

                

                collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
                collision.gameObject.GetComponent<playerMovement>().ableToMove = false;
                collision.gameObject.layer = 8;
                collision.GetComponent<SpriteRenderer>().sortingLayerName = "Teleporting";


            }
        }

        //----------------------------------------------------------------- PUSHABLE BOX -------------------------------

        if (collision.tag.Equals("pushableBox") && greenPortal.GetComponent<SpriteRenderer>().enabled == true && portalTeleportGreen.enteredGreenForBox == false)
        {
            enteredBlueForBox = true;
            // stopping all movement and transporting it to the midpoint
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.GetComponent<Rigidbody2D>().transform.position = blueMidPoint.transform.position;

            if (portalGun.attachedObjBlue.name.Equals("bottomWall"))
            {
                    
                blueBoxEnteredWall = "bottomWall";
                Debug.Log("layer set to pass through...");
                collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
                collision.gameObject.layer = 8;
                collision.GetComponent<SpriteRenderer>().sortingLayerName = "Teleporting";
                collision.GetComponent<SpriteRenderer>().sortingOrder = 0;
            }
            if (portalGun.attachedObjBlue.name.Equals("leftWall"))
            {

                blueBoxEnteredWall = "leftWall";
                Debug.Log("layer set to pass through...");
                collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
                collision.gameObject.layer = 8;
                collision.GetComponent<SpriteRenderer>().sortingLayerName = "Teleporting";
                collision.GetComponent<SpriteRenderer>().sortingOrder = 0;

                
                collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(-300f, 0f));
            }
            if (portalGun.attachedObjBlue.name.Equals("rightWall"))
            {

                blueBoxEnteredWall = "rightWall";
                Debug.Log("layer set to pass through...");
                collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
                collision.gameObject.layer = 8;
                collision.GetComponent<SpriteRenderer>().sortingLayerName = "Teleporting";
                collision.GetComponent<SpriteRenderer>().sortingOrder = 0;

                
                collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(300f, 0f));
            }
            if (portalGun.attachedObjBlue.name.Equals("topWall"))
            {
                
                blueBoxEnteredWall = "topWall";
                Debug.Log("layer set to pass through...");
                collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
                collision.gameObject.layer = 8;
                collision.GetComponent<SpriteRenderer>().sortingLayerName = "Teleporting";
                collision.GetComponent<SpriteRenderer>().sortingOrder = 0;
                collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 500f));
            }

        }
        //--------------------------------------------------------------------------- BULLET ------------------------------------

        if (collision.tag.Equals("bullet") && greenPortal.GetComponent<SpriteRenderer>().enabled == true)
        {
            // teleport the bullet to the portal and change its rotation to fit the wall its on
            if (portalGun.attachedObjGreen.name.Equals("rightWall"))
            {
                collision.transform.position = new Vector2(greenMidPoint.transform.position.x - 0.5f, greenMidPoint.transform.position.y);
                collision.transform.eulerAngles = new Vector3(0f, 180f, 0f);
                Debug.Log("THIS STATEMENT WORKED");
                //collision.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.GetComponent<Rigidbody2D>().velocity.x, 0f);

                if (portalGun.attachedObjBlue.name.Equals("bottomWall"))
                {
                    collision.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.GetComponent<Rigidbody2D>().velocity.y, 0f);
                }
                if (portalGun.attachedObjBlue.name.Equals("topWall"))
                {
                    collision.GetComponent<Rigidbody2D>().velocity = new Vector2(-collision.GetComponent<Rigidbody2D>().velocity.y, 0f);
                }
                if (portalGun.attachedObjBlue.name.Equals("leftWall"))
                {
                    collision.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.GetComponent<Rigidbody2D>().velocity.x, 0f);
                }
                if (portalGun.attachedObjBlue.name.Equals("rightWall"))
                {
                    collision.GetComponent<Rigidbody2D>().velocity = new Vector2(-collision.GetComponent<Rigidbody2D>().velocity.x, 0f);
                }


            }

            if (portalGun.attachedObjGreen.name.Equals("leftWall"))
            {
                collision.transform.position = new Vector2(greenMidPoint.transform.position.x + 0.5f, greenMidPoint.transform.position.y);
                collision.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                //collision.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.GetComponent<Rigidbody2D>().velocity.x, 0f);
                if (portalGun.attachedObjBlue.name.Equals("bottomWall"))
                {
                    collision.GetComponent<Rigidbody2D>().velocity = new Vector2(-collision.GetComponent<Rigidbody2D>().velocity.y, 0f);
                }
                if (portalGun.attachedObjBlue.name.Equals("topWall"))
                {
                    collision.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.GetComponent<Rigidbody2D>().velocity.y, 0f);
                }
                if (portalGun.attachedObjBlue.name.Equals("leftWall"))
                {
                    collision.GetComponent<Rigidbody2D>().velocity = new Vector2(-collision.GetComponent<Rigidbody2D>().velocity.x, 0f);
                }
                if (portalGun.attachedObjBlue.name.Equals("rightWall"))
                {
                    collision.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.GetComponent<Rigidbody2D>().velocity.x, 0f);
                }

            }

            if (portalGun.attachedObjGreen.name.Equals("bottomWall"))
            {
                Debug.Log("Yooooo");
                collision.transform.position = new Vector2(greenMidPoint.transform.position.x, greenMidPoint.transform.position.y + 0.5f);
                collision.transform.eulerAngles = new Vector3(0f, 0f, 90f);
                //collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, collision.GetComponent<Rigidbody2D>().velocity.x);
                if (portalGun.attachedObjBlue.name.Equals("bottomWall"))
                {
                    collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -collision.GetComponent<Rigidbody2D>().velocity.y);
                }
                if (portalGun.attachedObjBlue.name.Equals("topWall"))
                {
                    collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, collision.GetComponent<Rigidbody2D>().velocity.y);
                }
                if (portalGun.attachedObjBlue.name.Equals("leftWall"))
                {
                    collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -collision.GetComponent<Rigidbody2D>().velocity.x);
                }
                if (portalGun.attachedObjBlue.name.Equals("rightWall"))
                {
                    collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, collision.GetComponent<Rigidbody2D>().velocity.x);
                }

            }

            if (portalGun.attachedObjGreen.name.Equals("topWall"))
            {
                collision.transform.position = new Vector2(greenMidPoint.transform.position.x, greenMidPoint.transform.position.y - 0.5f);
                collision.transform.eulerAngles = new Vector3(0f, 0f, -90f);
                //collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, Mathf.Abs(collision.GetComponent<Rigidbody2D>().velocity.x));
                if (portalGun.attachedObjBlue.name.Equals("bottomWall"))
                {
                    collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, collision.GetComponent<Rigidbody2D>().velocity.y);
                }
                if (portalGun.attachedObjBlue.name.Equals("topWall"))
                {
                    collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -collision.GetComponent<Rigidbody2D>().velocity.y);
                }
                if (portalGun.attachedObjBlue.name.Equals("leftWall"))
                {
                    collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, collision.GetComponent<Rigidbody2D>().velocity.x);
                }
                if (portalGun.attachedObjBlue.name.Equals("rightWall"))
                {
                    collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -collision.GetComponent<Rigidbody2D>().velocity.x);

                }

            }
        }



    }

    //------------ON TRIGGER STAY-----------

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") && greenPortal.GetComponent<SpriteRenderer>().enabled == true && portalTeleportGreen.enteredGreen == false)
        {
            // putting velocity to 0 each time i enter a portal
            enteredBlue = true;
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.GetComponent<Rigidbody2D>().transform.position = blueMidPoint.transform.position;
            // if im teleporting from a left wall
            if (portalGun.attachedObjBlue.name.Equals("leftWall"))
            {
                blueEnteredWall = "leftWall";

                collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(-300f, 0f));

                // restricting player movement while teleporting
                collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
                collision.gameObject.GetComponent<playerMovement>().ableToMove = false;

                collision.gameObject.layer = 8;
                collision.GetComponent<SpriteRenderer>().sortingLayerName = "Teleporting";





                Debug.Log("Teleporting");

                //collision.transform.position = new Vector2(greenPortal.transform.position.x, greenPortal.transform.position.y + 2f);

            }

            if (portalGun.attachedObjBlue.name.Equals("bottomWall"))
            {
                blueEnteredWall = "bottomWall";

                collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -300f));

                Debug.Log("TOUCHED BLUE ENTRANCE");

                collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
                collision.gameObject.GetComponent<playerMovement>().ableToMove = false;
                collision.gameObject.layer = 8;
                collision.GetComponent<SpriteRenderer>().sortingLayerName = "Teleporting";



            }

            if (portalGun.attachedObjBlue.name.Equals("rightWall"))
            {
                blueEnteredWall = "rightWall";
                collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(300f, 0f));

                Debug.Log("TOUCHED BLUE ENTRANCE");

                collision.gameObject.GetComponent<playerMovement>().ableToMove = false;
                collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
                collision.gameObject.layer = 8;
                collision.GetComponent<SpriteRenderer>().sortingLayerName = "Teleporting";



            }
            if (portalGun.attachedObjBlue.name.Equals("topWall"))
            {
                blueEnteredWall = "topWall";

                Debug.Log("TOUCHED GREEN ENTRANCE");

                collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
                collision.gameObject.GetComponent<playerMovement>().ableToMove = false;
                collision.gameObject.layer = 8;
                collision.GetComponent<SpriteRenderer>().sortingLayerName = "Teleporting";


            }
        }

        // -------- FOR PUSHABLE BOX ----

        if (collision.tag.Equals("pushableBox") && greenPortal.GetComponent<SpriteRenderer>().enabled == true && portalTeleportGreen.enteredGreenForBox == false)
        {
            enteredBlueForBox = true;
            // stopping all movement and transporting it to the midpoint
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.GetComponent<Rigidbody2D>().transform.position = blueMidPoint.transform.position;

            if (portalGun.attachedObjBlue.name.Equals("bottomWall"))
            {

                blueBoxEnteredWall = "bottomWall";
                Debug.Log("layer set to pass through...");
                collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
                collision.gameObject.layer = 8;
                collision.GetComponent<SpriteRenderer>().sortingLayerName = "Teleporting";
                collision.GetComponent<SpriteRenderer>().sortingOrder = 0;
            }
            if (portalGun.attachedObjBlue.name.Equals("leftWall"))
            {

                blueBoxEnteredWall = "leftWall";
                Debug.Log("layer set to pass through...");
                collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
                collision.gameObject.layer = 8;
                collision.GetComponent<SpriteRenderer>().sortingLayerName = "Teleporting";
                collision.GetComponent<SpriteRenderer>().sortingOrder = 0;


                collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(-300f, 0f));
            }
            if (portalGun.attachedObjBlue.name.Equals("rightWall"))
            {

                blueBoxEnteredWall = "rightWall";
                Debug.Log("layer set to pass through...");
                collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
                collision.gameObject.layer = 8;
                collision.GetComponent<SpriteRenderer>().sortingLayerName = "Teleporting";
                collision.GetComponent<SpriteRenderer>().sortingOrder = 0;


                collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(300f, 0f));
            }
            if (portalGun.attachedObjBlue.name.Equals("topWall"))
            {

                blueBoxEnteredWall = "topWall";
                Debug.Log("layer set to pass through...");
                collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
                collision.gameObject.layer = 8;
                collision.GetComponent<SpriteRenderer>().sortingLayerName = "Teleporting";
                collision.GetComponent<SpriteRenderer>().sortingOrder = 0;
            }

        }
    }
}
