using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalGun : MonoBehaviour
{

    
    

    // Linecast related to determine the wall that i want to open a portal on and where the lazer should be cast from etc...
    public static RaycastHit2D lazerHitPointBlue,lazerHitPointGreen;
    Transform lazerStartPoint;
    public static Vector2 lazerHitCoord;

    public static bool doOnce = false;

    
    

    //test after first raycast
    RaycastHit2D testCastLeft;
    RaycastHit2D testCastRight;

    // limits for the transformations
    Transform blueLeftLimit, blueRightLimit;
    Transform greenLeftLimit, greenRightLimit;
    float greenPortalSize;


    // green and blue portals and character
    GameObject bluePortal;
    GameObject greenPortal;
    GameObject astroBuddy;


    // Attached object
    public static GameObject attachedObjGreen, attachedObjBlue;

    //bools to determine whether the portal is active or not
    public static bool isBluePortalOpen;
    public static bool isGreenPortalOpen;

    //able to open portal bool
    public static bool ableToOpenGreen = true, ableToOpenBlue = true;


    void Start()
    {
        // instantiating lazerStartPoint to the first transform child
        lazerStartPoint = this.transform.GetChild(0);

        //finding the green and blue portals at the start of the level if they exist
        if (GameObject.Find("bluePortal") != null)
        {
            bluePortal = GameObject.Find("bluePortal");
            blueLeftLimit = bluePortal.transform.GetChild(0);
            blueRightLimit = bluePortal.transform.GetChild(1);
        }
        if (GameObject.Find("greenPortal") != null)
        {
            greenPortal = GameObject.Find("greenPortal");

            greenLeftLimit = greenPortal.transform.GetChild(0);
            greenRightLimit = greenPortal.transform.GetChild(1);
            greenPortalSize = Mathf.Abs(greenRightLimit.position.x - greenLeftLimit.position.x) / 2;

        }

        if (GameObject.Find("AstroStay") != null)
        {
            astroBuddy = GameObject.Find("AstroStay");

     

        }



    }
    private void FixedUpdate()
    {
        Debug.Log("blue obj : " + attachedObjBlue + " green obj : " + attachedObjGreen);
        Debug.Log("lazer collider green : " + lazerHitPointGreen.collider + "lazer collider blue " + lazerHitPointBlue.collider);
        Debug.Log("ABLE TO OPEN GREEN : " + ableToOpenGreen + " ABLE TO OPEN BLUE : " + ableToOpenBlue);
        Debug.Log("attached obj Blue : " + attachedObjBlue + " attached obj Green : " + attachedObjGreen);
        Debug.Log(astroBuddy.name);


    }


    void Update()
    {
        if (dragScript.objCurrentCarry)
        {
            resetPortals();
            
        }


        if (portalResetChecker.canResetPortal == true && portalResetChecker.canResetPortalBox == true && astroBuddy.layer == 2)
        {
            resetPortals();
        }
        // if the timescale is 1 , which means the game is not paused
        if (Time.timeScale == 1)
        {
            if ((portalTeleportGreen.enteredGreen == false && portalTeleportBlue.enteredBlue == false) &&
                astroBuddy.layer == 2)
            {
                shootBluePortal();
                shootGreenPortal();
                
            }
        }

        









        // Debug.Log("lazerhitpoint x : " + lazerHitPointBlue.point.x + " green left limit : " + greenLeftLimit.position.x + " green right limit : " + greenRightLimit.position.x);

        // Debug.Log(ableToOpenGreen);

        //  Debug.Log("green left limit y " + greenLeftLimit.position.y);
        //  Debug.Log("green right limit y " + greenRightLimit.position.y);

        // Debug.Log("transform child 0 : " + attachedObj.transform.GetChild(0).position.y);
        //  Debug.Log("transform child 1 : " + attachedObj.transform.GetChild(1).position.y);








    }


    // functio to shoot the blue colored portal to the given wall
    void shootBluePortal()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // send a line from the start point to the mouse position on the screen , first collider to hit will be the hit point
            lazerHitPointBlue = Physics2D.Linecast(lazerStartPoint.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            // ASSIGNING ATTACHED OBJ ----
            //attachedObj = lazerHitPoint.collider.gameObject;


            // debug related
            // Debug.Log(lazerHitPoint.collider);
            // Debug.DrawLine(lazerStartPoint.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));


            // if the lazerhitpoint is not null , do the rest
            if (lazerHitPointBlue.collider != null)
            {

                if (lazerHitPointBlue.collider.GetComponent<portallableWall>() != null)
                {
                    attachedObjBlue = lazerHitPointBlue.collider.gameObject;
                    overLappingPortalsBlueClick();
                }

                
                

                // if the collider is a portallable left wall
                if (lazerHitPointBlue.collider.GetComponent<portallableWall>() != null &&
                    lazerHitPointBlue.point.y + greenPortalSize <= attachedObjBlue.transform.GetChild(0).position.y &&
                    lazerHitPointBlue.point.y - greenPortalSize >= attachedObjBlue.transform.GetChild(1).position.y &&
                    attachedObjBlue.tag == "leftWall"&&
                    ableToOpenBlue == true)

                {
                    
                    // set to true , so we can click again to disable it
                    isBluePortalOpen = true;
                    // setting the portals location to the hit wall and enabling the sprite renderer
                    //bluePortal.GetComponent<SpriteRenderer>().enabled = true;
                    bluePortal.transform.position = lazerHitPointBlue.point;
                    bluePortal.transform.eulerAngles = -lazerHitPointBlue.collider.transform.eulerAngles;
                    bluePortal.GetComponent<SpriteRenderer>().enabled = true;

                    // Debug.Log("portallable wall is active");


                }
                // if its a right wall
                if (lazerHitPointBlue.collider.GetComponent<portallableWall>() != null &&
                    lazerHitPointBlue.point.y + greenPortalSize <= attachedObjBlue.transform.GetChild(0).position.y &&
                    lazerHitPointBlue.point.y - greenPortalSize >= attachedObjBlue.transform.GetChild(1).position.y &&
                    attachedObjBlue.tag == "rightWall" &&
                    ableToOpenBlue == true)

                {
                    
                    // set to true , so we can click again to disable it
                    isBluePortalOpen = true;
                    // setting the portals location to the hit wall and enabling the sprite renderer
                    //bluePortal.GetComponent<SpriteRenderer>().enabled = true;
                    bluePortal.transform.position = lazerHitPointBlue.point;
                    bluePortal.transform.eulerAngles = lazerHitPointBlue.collider.transform.eulerAngles;
                    bluePortal.GetComponent<SpriteRenderer>().enabled = true;

                    // Debug.Log("portallable wall is active");


                }
                // if its a portallable bottom wall
                if (lazerHitPointBlue.collider.GetComponent<portallableWall>() != null &&
                    lazerHitPointBlue.point.x + greenPortalSize <= attachedObjBlue.transform.GetChild(0).position.x &&
                    lazerHitPointBlue.point.x - greenPortalSize >= attachedObjBlue.transform.GetChild(1).position.x &&
                    attachedObjBlue.tag == "bottomWall"&&
                    ableToOpenBlue == true)

                {


                    // set to true , so we can click again to disable it
                    isBluePortalOpen = true;
                    // setting the portals location to the hit wall and enabling the sprite renderer
                    bluePortal.GetComponent<SpriteRenderer>().enabled = true;
                    bluePortal.transform.position = lazerHitPointBlue.point;
                    bluePortal.transform.rotation = lazerHitPointBlue.collider.transform.rotation;

                    // Debug.Log("portallable wall is active");
                }
                // if its a portallable yop wall
                if (lazerHitPointBlue.collider.GetComponent<portallableWall>() != null &&
                    lazerHitPointBlue.point.x + greenPortalSize <= attachedObjBlue.transform.GetChild(0).position.x &&
                    lazerHitPointBlue.point.x - greenPortalSize >= attachedObjBlue.transform.GetChild(1).position.x &&
                    attachedObjBlue.tag == "topWall" &&
                    ableToOpenBlue == true)

                {


                    // set to true , so we can click again to disable it
                    isBluePortalOpen = true;
                    // setting the portals location to the hit wall and enabling the sprite renderer
                    bluePortal.GetComponent<SpriteRenderer>().enabled = true;
                    bluePortal.transform.position = lazerHitPointBlue.point;
                    bluePortal.transform.rotation = new Quaternion(0f, 0f, 180f, 0f);

                    // Debug.Log("portallable wall is active");
                }



            }

            // if the collider is null or the portal is open , clicking again will remove the portal from the screen TEEEEEEEEEEEEEEEEST HEEEEEREE
            else if (lazerHitPointBlue.collider == null && portalResetChecker.canResetPortal == true && portalResetChecker.canResetPortalBox == true)
            {
                // if the blue portal is open , clicking again will disable its sprite renderer
                if (bluePortal.GetComponent<SpriteRenderer>().enabled == true)
                {
                    isBluePortalOpen = false;
                    bluePortal.GetComponent<SpriteRenderer>().enabled = false;
                    bluePortal.transform.position = new Vector2(-100f, -100f);
                    // TEST
                    attachedObjBlue = null;
                }


            }
            // TEEEEEEEEEEEEEEEEEEEEEEEEEEEEEST HEREEEE
            else
            {
                if (bluePortal.GetComponent<SpriteRenderer>().enabled == true && portalResetChecker.canResetPortal == true && portalResetChecker.canResetPortalBox == true)
                {
                    isBluePortalOpen = false;
                    bluePortal.GetComponent<SpriteRenderer>().enabled = false;
                    bluePortal.transform.position = new Vector2(-100f, -100f);
                    // TEST
                    attachedObjBlue = null;
                }
            }


        }



        // end of bluePortal script
    }


    void shootGreenPortal()
    {

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            // send a line from the start point to the mouse position on the screen , first collider to hit will be the hit point
            lazerHitPointGreen = Physics2D.Linecast(lazerStartPoint.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            
            
            

            Debug.DrawLine(lazerStartPoint.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if (lazerHitPointGreen.collider != null)
            {
                Debug.Log("Green collider name is " + lazerHitPointGreen.collider.name);
            }


            // debug related
            // Debug.Log(lazerHitPoint.collider);
            // Debug.DrawLine(lazerStartPoint.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));


            // if the lazerhitpoint is not null , do the rest WOOORKING HERE ATM
            if (lazerHitPointGreen.collider != null)
            {
                if (lazerHitPointGreen.collider.GetComponent<portallableWall>() != null)
                {
                    attachedObjGreen = lazerHitPointGreen.collider.gameObject;
                    overLappingPortalsGreenClick();
                }
                

                lazerHitCoord = lazerHitPointGreen.point;
                
                // if the collider is a portallable wall and its a upfacing left wall
                if (lazerHitPointGreen.collider.GetComponent<portallableWall>() != null &&
                    lazerHitPointGreen.point.y + greenPortalSize <= attachedObjGreen.transform.GetChild(0).position.y &&
                    lazerHitPointGreen.point.y - greenPortalSize >= attachedObjGreen.transform.GetChild(1).position.y &&
                    attachedObjGreen.tag == "leftWall" &&
                    ableToOpenGreen == true)

                {
                    
                    Debug.Log("WORKIIING");
                    // set to true , so we can click again to disable it
                    isGreenPortalOpen = true;
                    // setting the portals location to the hit wall and enabling the sprite renderer
                    greenPortal.GetComponent<SpriteRenderer>().enabled = true;
                    greenPortal.transform.position = lazerHitPointGreen.point;
                    greenPortal.transform.eulerAngles = -lazerHitPointGreen.collider.transform.eulerAngles;

                    // Debug.Log("portallable wall is active");


                }

                if (lazerHitPointGreen.collider.GetComponent<portallableWall>() != null &&
                   lazerHitPointGreen.point.y + greenPortalSize <= attachedObjGreen.transform.GetChild(0).position.y &&
                   lazerHitPointGreen.point.y - greenPortalSize >= attachedObjGreen.transform.GetChild(1).position.y &&
                   attachedObjGreen.tag == "rightWall" &&
                   ableToOpenGreen == true)
                  

                {
                    

                    // set to true , so we can click again to disable it
                    isGreenPortalOpen = true;
                    // setting the portals location to the hit wall and enabling the sprite renderer
                    greenPortal.GetComponent<SpriteRenderer>().enabled = true;
                    greenPortal.transform.position = lazerHitPointGreen.point;
                    greenPortal.transform.eulerAngles = lazerHitPointGreen.collider.transform.eulerAngles;

                    // Debug.Log("portallable wall is active");


                }

                if (lazerHitPointGreen.collider.GetComponent<portallableWall>() != null &&
                    lazerHitPointGreen.point.x + greenPortalSize <= attachedObjGreen.transform.GetChild(0).position.x &&
                    lazerHitPointGreen.point.x - greenPortalSize >= attachedObjGreen.transform.GetChild(1).position.x &&
                    attachedObjGreen.tag == "bottomWall"&&
                    ableToOpenGreen == true)

                {
                    

                    // set to true , so we can click again to disable it
                    isGreenPortalOpen = true;
                    // setting the portals location to the hit wall and enabling the sprite renderer
                    greenPortal.GetComponent<SpriteRenderer>().enabled = true;
                    greenPortal.transform.position = lazerHitPointGreen.point;
                    greenPortal.transform.rotation = lazerHitPointGreen.collider.transform.rotation;

                    // Debug.Log("portallable wall is active");
                }

                if (lazerHitPointGreen.collider.GetComponent<portallableWall>() != null &&
                    lazerHitPointGreen.point.x + greenPortalSize <= attachedObjGreen.transform.GetChild(0).position.x &&
                    lazerHitPointGreen.point.x - greenPortalSize >= attachedObjGreen.transform.GetChild(1).position.x &&
                    attachedObjGreen.tag == "topWall" &&
                    ableToOpenGreen == true)

                {
                    
                    Debug.Log("asdokfapsodHEEEEkasopdasdas");
                    // set to true , so we can click again to disable it
                    isGreenPortalOpen = true;
                    // setting the portals location to the hit wall and enabling the sprite renderer
                    greenPortal.GetComponent<SpriteRenderer>().enabled = true;
                    greenPortal.transform.position = lazerHitPointGreen.point;
                    greenPortal.transform.rotation = new Quaternion(0f, 0f, 180f ,0f);

                    // Debug.Log("portallable wall is active");
                }



            }

            // if the collider is null or the portal is open , clicking again will remove the portal from the screen
            else if (lazerHitPointGreen.collider == null)
            {
                Debug.Log("GREEN NULL CLICK HAPPENED");
                // if the blue portal is open , clicking again will disable its sprite renderer TEST HERE -------------------------------------
                if (greenPortal.GetComponent<SpriteRenderer>().enabled == true && portalResetChecker.canResetPortal == true && portalResetChecker.canResetPortalBox == true)
                {
                    isGreenPortalOpen = false;
                    greenPortal.GetComponent<SpriteRenderer>().enabled = false;
                    greenPortal.transform.position = new Vector2(-200f, -200f);
                    //TEST
                    attachedObjGreen = null;
                }


            }
            // TEEEEEEEEEEEEEST HERE
            else
            {
                Debug.Log("ELSE STATEMENT GREEN HAPPENED");
                if (greenPortal.GetComponent<SpriteRenderer>().enabled == true && portalResetChecker.canResetPortal == true && portalResetChecker.canResetPortalBox == true)
                {
                    isGreenPortalOpen = false;
                    greenPortal.GetComponent<SpriteRenderer>().enabled = false;
                    greenPortal.transform.position = new Vector2(-200f, -200f);

                    //TEST
                    attachedObjGreen = null;
                }

            }




        }



        // end of greenPortal script
    }




    public void overLappingPortalsBlueClick()
    {

        if (lazerHitPointBlue.collider != null)
        {
            if ((inBetween(0.5f, lazerHitPointBlue.point.x, greenRightLimit.position.x) ||
                inBetween(0.5f, lazerHitPointBlue.point.x, greenLeftLimit.position.x)) &&
                (inBetween(0.5f, lazerHitPointBlue.point.y ,greenLeftLimit.position.y) ||
                inBetween(0.5f, lazerHitPointBlue.point.y , greenRightLimit.position.y)))
            {

                Debug.Log("it is between BLUE");
                ableToOpenBlue = false;

            }
            else
            {
                ableToOpenBlue = true;
            }
        }

       

    }

    
    
    public void overLappingPortalsGreenClick()
    {


        if (lazerHitPointGreen.collider != null)
        {
            if ((inBetween(0.5f, lazerHitPointGreen.point.x, blueRightLimit.position.x) ||
                inBetween(0.5f, lazerHitPointGreen.point.x, blueLeftLimit.position.x)) &&
                (inBetween(0.5f, lazerHitPointGreen.point.y, blueLeftLimit.position.y) ||
                inBetween(0.5f, lazerHitPointGreen.point.y, blueRightLimit.position.y)))
            {

                Debug.Log("it is between GREEN");
                ableToOpenGreen = false;

            }
            else
            {
                ableToOpenGreen = true;
            }
        }


    }
    


    // check if inbetween given constraints
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

    public void resetPortals()
    {


        if (Input.GetKeyDown("f") )
        {
            attachedObjBlue = null;
            attachedObjGreen = null;

            bluePortal.transform.position = new Vector2(150f, 150f);
            greenPortal.transform.position = new Vector2(-150f, -150f);

            ableToOpenBlue = true;
            ableToOpenGreen = true;

            greenPortal.GetComponent<SpriteRenderer>().enabled = false;
            bluePortal.GetComponent<SpriteRenderer>().enabled = false;

            portalTeleportBlue.enteredBlue = false;
            portalTeleportGreen.enteredGreen = false;

            portalTeleportBlue.enteredBlueForBox = false;
            portalTeleportGreen.enteredGreenForBox = false;
        }


    }

    /* save for later if needed
     *   // another raycast done to see if it is within the bounds of the wall
                Transform lazerStartLeft = bluePortal.transform.GetChild(0);
                Transform lazerStartRight = bluePortal.transform.GetChild(1);

                testCastLeft = Physics2D.Raycast(lazerStartLeft.position, -lazerHitPoint.normal);
                testCastRight = Physics2D.Raycast(lazerStartRight.position, -lazerHitPoint.normal);
                Debug.DrawRay(lazerStartRight.position, -lazerHitPoint.normal);

                if (lazerHitPoint.collider == testCastRight.collider)
                {

                    ableToOpenBlue = true;
                }
                else
                {
                    ableToOpenBlue = false;
                }
    */









    // end of class
}


