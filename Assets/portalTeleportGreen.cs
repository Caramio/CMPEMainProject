using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalTeleportGreen : MonoBehaviour
{
   

    // green and blue portals
    GameObject bluePortal;
    GameObject greenPortal;

    // portal midpoints
    Transform blueMidPoint, greenMidPoint;
    // test later
    public static bool enteredGreen = false;

    // bool for box
    public static bool enteredGreenForBox = false;

    // bool to see if inside teleporting phase
    public static bool isInsidePortal = false;

    // string to see which wall i entered from
    public static string greenEnteredWall;
    public static string greenBoxEnteredWall;

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
        // TELEPORTING THE PLAYER
        if (collision.tag.Equals("Player") && bluePortal.GetComponent<SpriteRenderer>().enabled == true && portalTeleportBlue.enteredBlue == false)
        {
            // putting velocity to 0 each time i enter a portal
            enteredGreen = true;
            // set the velocity of the character to 0 
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.GetComponent<Rigidbody2D>().transform.position = greenMidPoint.transform.position;
            // if im teleporting from a left wall
            if (portalGun.attachedObjGreen.name.Equals("leftWall"))
            {
                greenEnteredWall = "leftWall";
                // setting gameobject layer to 8 ( portal physics ) so i can move freely inside the wall , sorting layer name to Teleporting so the sprite mask
                // will cover my player                
                // restricting player movement while teleporting

                collision.gameObject.GetComponent<playerMovement>().ableToMove = false;
                collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
               collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(-300f, 0f));
                

                collision.gameObject.layer = 8;
                collision.GetComponent<SpriteRenderer>().sortingLayerName = "Teleporting";
                //collision.GetComponent<Rigidbody2D>().velocity = new Vector2(-5f,0f);

                Debug.Log("Teleporting");

                //collision.transform.position = new Vector2(greenPortal.transform.position.x, greenPortal.transform.position.y + 2f);

            }
            if (portalGun.attachedObjGreen.name.Equals("bottomWall"))
            {
                greenEnteredWall = "bottomWall";
                
                collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -300f));


                collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
                collision.gameObject.GetComponent<playerMovement>().ableToMove = false;                        
                collision.gameObject.layer = 8;
                collision.GetComponent<SpriteRenderer>().sortingLayerName = "Teleporting";


            }

            if (portalGun.attachedObjGreen.name.Equals("rightWall"))
            {
                greenEnteredWall = "rightWall";
                Debug.Log("TOUCHED GREEN ENTRANCE");
                collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(300f, 0f));

                collision.gameObject.GetComponent<playerMovement>().ableToMove = false;
                collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
                collision.gameObject.layer = 8;
                collision.GetComponent<SpriteRenderer>().sortingLayerName = "Teleporting";


            }

            if (portalGun.attachedObjGreen.name.Equals("topWall"))
            {
                greenEnteredWall = "topWall";
                Debug.Log("TOUCHED GREEN ENTRANCE");
                collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(500f, 0f));

                collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
                collision.gameObject.GetComponent<playerMovement>().ableToMove = false;
                collision.gameObject.layer = 8;
                collision.GetComponent<SpriteRenderer>().sortingLayerName = "Teleporting";


            }
        }

        // if the entering obj is a box------------------------------------------

        if (collision.tag.Equals("pushableBox") && bluePortal.GetComponent<SpriteRenderer>().enabled == true && portalTeleportBlue.enteredBlueForBox == false)
        {
            enteredGreenForBox = true;
            // stopping all movement and transporting it to the midpoint
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.GetComponent<Rigidbody2D>().transform.position = greenMidPoint.transform.position;

            if (portalGun.attachedObjGreen.name.Equals("bottomWall"))
            {

                greenBoxEnteredWall = "bottomWall";
                Debug.Log("layer set to pass through...");
                collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
                collision.gameObject.layer = 8;
                collision.GetComponent<SpriteRenderer>().sortingLayerName = "Teleporting";
                collision.GetComponent<SpriteRenderer>().sortingOrder = 0;
            }
            if (portalGun.attachedObjGreen.name.Equals("leftWall"))
            {

                greenBoxEnteredWall = "leftWall";
                Debug.Log("LEFT WALL PASSING");
                collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
                collision.gameObject.layer = 8;
                collision.GetComponent<SpriteRenderer>().sortingLayerName = "Teleporting";
                collision.GetComponent<SpriteRenderer>().sortingOrder = 0;

                
                collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(-500f, 0f));
            }
            if (portalGun.attachedObjGreen.name.Equals("rightWall"))
            {

                greenBoxEnteredWall = "rightWall";
                Debug.Log("layer set to pass through...");
                collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
                collision.gameObject.layer = 8;
                collision.GetComponent<SpriteRenderer>().sortingLayerName = "Teleporting";
                collision.GetComponent<SpriteRenderer>().sortingOrder = 0;

                
                collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(300f, 0f));
            }
            if (portalGun.attachedObjGreen.name.Equals("topWall"))
            {

                greenBoxEnteredWall = "topWall";
                Debug.Log("layer set to pass through...");
                collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
                collision.gameObject.layer = 8;
                collision.GetComponent<SpriteRenderer>().sortingLayerName = "Teleporting";
                collision.GetComponent<SpriteRenderer>().sortingOrder = 0;

                collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 500f));
            }

        }

        // if a bullet collides with the portal WORK ON THIS ------------------------///////////////----------------------------------------------
        if (collision.tag.Equals("bullet") && bluePortal.GetComponent<SpriteRenderer>().enabled == true)
        {
            // teleport the bullet to the portal and change its rotation to fit the wall its on
            if (portalGun.attachedObjBlue.name.Equals("rightWall"))
            {
                collision.transform.position = new Vector2(blueMidPoint.transform.position.x - 0.5f, blueMidPoint.transform.position.y);
                collision.transform.eulerAngles = new Vector3(0f, 180f, 0f);
                //collision.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.GetComponent<Rigidbody2D>().velocity.x, 0f);
                if (portalGun.attachedObjGreen.name.Equals("bottomWall"))
                {
                    collision.GetComponent<Rigidbody2D>().velocity = new Vector2( collision.GetComponent<Rigidbody2D>().velocity.y , 0f);
                }
                if (portalGun.attachedObjGreen.name.Equals("topWall"))
                {
                    collision.GetComponent<Rigidbody2D>().velocity = new Vector2( -collision.GetComponent<Rigidbody2D>().velocity.y , 0f);
                }
                if (portalGun.attachedObjGreen.name.Equals("leftWall"))
                {
                    collision.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.GetComponent<Rigidbody2D>().velocity.x, 0f);
                }
                if (portalGun.attachedObjGreen.name.Equals("rightWall"))
                {
                    collision.GetComponent<Rigidbody2D>().velocity = new Vector2(-collision.GetComponent<Rigidbody2D>().velocity.x, 0f);
                }
            }
            //------
            if (portalGun.attachedObjBlue.name.Equals("leftWall"))
            {
                collision.transform.position = new Vector2(blueMidPoint.transform.position.x + 0.5f, blueMidPoint.transform.position.y);
                collision.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                //collision.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.GetComponent<Rigidbody2D>().velocity.x, 0f);
                if (portalGun.attachedObjGreen.name.Equals("bottomWall"))
                {
                    collision.GetComponent<Rigidbody2D>().velocity = new Vector2(-collision.GetComponent<Rigidbody2D>().velocity.y ,0f);
                }
                if (portalGun.attachedObjGreen.name.Equals("topWall"))
                {
                    collision.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.GetComponent<Rigidbody2D>().velocity.y , 0f);
                }
                if (portalGun.attachedObjGreen.name.Equals("leftWall"))
                {
                    collision.GetComponent<Rigidbody2D>().velocity = new Vector2(-collision.GetComponent<Rigidbody2D>().velocity.x, 0f);
                }
                if (portalGun.attachedObjGreen.name.Equals("rightWall"))
                {
                    collision.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.GetComponent<Rigidbody2D>().velocity.x, 0f);
                }
            }
            //-----
            if (portalGun.attachedObjBlue.name.Equals("bottomWall"))
            {
                
                collision.transform.position = new Vector2(blueMidPoint.transform.position.x, blueMidPoint.transform.position.y + 0.5f);
                collision.transform.eulerAngles = new Vector3(0f, 0f, 90f);
                //collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, collision.GetComponent<Rigidbody2D>().velocity.x);
                if (portalGun.attachedObjGreen.name.Equals("bottomWall"))
                {
                    collision.GetComponent<Rigidbody2D>().velocity = new Vector2( 0f , -collision.GetComponent<Rigidbody2D>().velocity.y);
                }
                if (portalGun.attachedObjGreen.name.Equals("topWall"))
                {
                    collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, collision.GetComponent<Rigidbody2D>().velocity.y);
                }
                if (portalGun.attachedObjGreen.name.Equals("leftWall"))
                {
                    collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0f , -collision.GetComponent<Rigidbody2D>().velocity.x);
                }
                if (portalGun.attachedObjGreen.name.Equals("rightWall"))
                {
                    collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0f , collision.GetComponent<Rigidbody2D>().velocity.x);
                }



            }
            //-----
            if (portalGun.attachedObjBlue.name.Equals("topWall"))
            {
                collision.transform.position = new Vector2(blueMidPoint.transform.position.x, blueMidPoint.transform.position.y - 0.5f);
                collision.transform.eulerAngles = new Vector3(0f, 0f, -90f);
                //collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, Mathf.Abs(collision.GetComponent<Rigidbody2D>().velocity.x));

                if (portalGun.attachedObjGreen.name.Equals("bottomWall"))
                {
                    collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, collision.GetComponent<Rigidbody2D>().velocity.y);
                }
                if (portalGun.attachedObjGreen.name.Equals("topWall"))
                {
                    collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -collision.GetComponent<Rigidbody2D>().velocity.y);
                }
                if (portalGun.attachedObjGreen.name.Equals("leftWall"))
                {
                    collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, collision.GetComponent<Rigidbody2D>().velocity.x);
                }
                if (portalGun.attachedObjGreen.name.Equals("rightWall"))
                {
                    collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0f ,-collision.GetComponent<Rigidbody2D>().velocity.x);

                }

            }
        }
   

    }


    //-------ON TRIGGER STAY---------
    private void OnTriggerStay2D(Collider2D collision)
    {
        // TELEPORTING THE PLAYER
        if (collision.tag.Equals("Player") && bluePortal.GetComponent<SpriteRenderer>().enabled == true && portalTeleportBlue.enteredBlue == false)
        {
            // putting velocity to 0 each time i enter a portal
            enteredGreen = true;
            // set the velocity of the character to 0 
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.GetComponent<Rigidbody2D>().transform.position = greenMidPoint.transform.position;
            // if im teleporting from a left wall
            if (portalGun.attachedObjGreen.name.Equals("leftWall"))
            {
                greenEnteredWall = "leftWall";
                // setting gameobject layer to 8 ( portal physics ) so i can move freely inside the wall , sorting layer name to Teleporting so the sprite mask
                // will cover my player                
                // restricting player movement while teleporting

                collision.gameObject.GetComponent<playerMovement>().ableToMove = false;
                collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
                collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(-300f, 0f));


                collision.gameObject.layer = 8;
                collision.GetComponent<SpriteRenderer>().sortingLayerName = "Teleporting";
                //collision.GetComponent<Rigidbody2D>().velocity = new Vector2(-5f,0f);

                Debug.Log("Teleporting");

                //collision.transform.position = new Vector2(greenPortal.transform.position.x, greenPortal.transform.position.y + 2f);

            }
            if (portalGun.attachedObjGreen.name.Equals("bottomWall"))
            {
                greenEnteredWall = "bottomWall";

                collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -300f));


                collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
                collision.gameObject.GetComponent<playerMovement>().ableToMove = false;
                collision.gameObject.layer = 8;
                collision.GetComponent<SpriteRenderer>().sortingLayerName = "Teleporting";


            }

            if (portalGun.attachedObjGreen.name.Equals("rightWall"))
            {
                greenEnteredWall = "rightWall";
                Debug.Log("TOUCHED GREEN ENTRANCE");
                collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(300f, 0f));

                collision.gameObject.GetComponent<playerMovement>().ableToMove = false;
                collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
                collision.gameObject.layer = 8;
                collision.GetComponent<SpriteRenderer>().sortingLayerName = "Teleporting";


            }

            if (portalGun.attachedObjGreen.name.Equals("topWall"))
            {
                greenEnteredWall = "topWall";
                Debug.Log("TOUCHED GREEN ENTRANCE");
                collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(-500f, 0f));

                collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
                collision.gameObject.GetComponent<playerMovement>().ableToMove = false;
                collision.gameObject.layer = 8;
                collision.GetComponent<SpriteRenderer>().sortingLayerName = "Teleporting";


            }
        }

        // FOR PUSHABLE BOX---------------------
        if (collision.tag.Equals("pushableBox") && bluePortal.GetComponent<SpriteRenderer>().enabled == true && portalTeleportBlue.enteredBlueForBox == false)
        {
            enteredGreenForBox = true;
            // stopping all movement and transporting it to the midpoint
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.GetComponent<Rigidbody2D>().transform.position = greenMidPoint.transform.position;

            if (portalGun.attachedObjGreen.name.Equals("bottomWall"))
            {

                greenBoxEnteredWall = "bottomWall";
                Debug.Log("layer set to pass through...");
                collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
                collision.gameObject.layer = 8;
                collision.GetComponent<SpriteRenderer>().sortingLayerName = "Teleporting";
                collision.GetComponent<SpriteRenderer>().sortingOrder = 0;
            }
            if (portalGun.attachedObjGreen.name.Equals("leftWall"))
            {

                greenBoxEnteredWall = "leftWall";
                Debug.Log("LEFT WALL PASSING");
                collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
                collision.gameObject.layer = 8;
                collision.GetComponent<SpriteRenderer>().sortingLayerName = "Teleporting";
                collision.GetComponent<SpriteRenderer>().sortingOrder = 0;


                collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(-300f, 0f));
            }
            if (portalGun.attachedObjGreen.name.Equals("rightWall"))
            {

                greenBoxEnteredWall = "rightWall";
                Debug.Log("layer set to pass through...");
                collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
                collision.gameObject.layer = 8;
                collision.GetComponent<SpriteRenderer>().sortingLayerName = "Teleporting";
                collision.GetComponent<SpriteRenderer>().sortingOrder = 0;


                collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(300f, 0f));
            }
            if (portalGun.attachedObjGreen.name.Equals("topWall"))
            {

                greenBoxEnteredWall = "topWall";
                Debug.Log("layer set to pass through...");
                collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
                collision.gameObject.layer = 8;
                collision.GetComponent<SpriteRenderer>().sortingLayerName = "Teleporting";
                collision.GetComponent<SpriteRenderer>().sortingOrder = 0;
            }

        }
    }
}
