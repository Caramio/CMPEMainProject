using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportMidPointGreen : MonoBehaviour
{
    GameObject greenPortal, bluePortal;
    GameObject portalExitPointGreen;

    Transform blueMidPoint, greenMidPoint;

    public static bool isAtPortalMid = false;

    void Start()
    {

        if (GameObject.Find("teleportExitPointGreen") != null)
        {

            portalExitPointGreen = GameObject.Find("teleportExitPointGreen");

        }

        if (GameObject.Find("bluePortal") != null)
        {
            bluePortal = GameObject.Find("bluePortal");
            blueMidPoint = bluePortal.transform.GetChild(2);



        }
        if (GameObject.Find("greenPortal") != null)
        {
            greenPortal = GameObject.Find("greenPortal");
            


        }



    }


    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") && portalTeleportBlue.enteredBlue == false)
        {



            if (portalGun.attachedObjBlue != null)
            {
                if (portalGun.attachedObjBlue.name.Equals("leftWall"))
                {
                    
                    collision.transform.position = new Vector2(blueMidPoint.transform.position.x +0.2f, blueMidPoint.transform.position.y);
                    collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(500f, 0f));
                }
                if (portalGun.attachedObjBlue.name.Equals("rightWall"))
                {
                    
                    collision.transform.position = new Vector2(blueMidPoint.transform.position.x -0.2f, blueMidPoint.transform.position.y);
                    collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(-500f, 0f));
                }
                if (portalGun.attachedObjBlue.name.Equals("bottomWall"))
                {
                    collision.transform.position = new Vector2(blueMidPoint.transform.position.x, blueMidPoint.transform.position.y + 0.2f);
                    // adding force depending on which wall i entered from
                    if (portalTeleportGreen.greenEnteredWall == "bottomWall")
                    {
                        collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 600f));
                    }
                    if (portalTeleportGreen.greenEnteredWall == "leftWall" || portalTeleportGreen.greenEnteredWall == "rightWall")
                    {
                        collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 200f));
                    }
                }
                if (portalGun.attachedObjBlue.name.Equals("topWall"))
                {
                    collision.transform.position = new Vector2(blueMidPoint.transform.position.x, blueMidPoint.transform.position.y -0.6f);
                    collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -500f));
                }
            }


            collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            collision.gameObject.GetComponent<playerMovement>().ableToMove = true;
            collision.gameObject.layer = 2;
            collision.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
            Debug.Log("Workingggggggg");


        }
        // if its a pushableBox that hit the middlePoint
        if (collision.tag.Equals("pushableBox") && portalTeleportBlue.enteredBlueForBox == false)
        {
            
            if (portalGun.attachedObjBlue.name.Equals("bottomWall"))
            {

                collision.transform.position = new Vector2(blueMidPoint.transform.position.x, blueMidPoint.transform.position.y + 0.5f);
                // adding force depending on which wall i entered from
                if (portalTeleportGreen.greenBoxEnteredWall == "bottomWall")
                {
                    Debug.Log("TELEPORTED FROM MIDPOINT GREEN");
                    collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 500f));
                }
                if (portalTeleportGreen.greenBoxEnteredWall == "leftWall" || portalTeleportGreen.greenBoxEnteredWall == "rightWall")
                {
                    Debug.Log("Yawwwasdsadsadasdasdsa");
                    collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 500f));
                }
            }
            if (portalGun.attachedObjBlue.name.Equals("leftWall"))
            {

                Debug.Log("Blue was on a left wall");
                collision.transform.position = new Vector2(blueMidPoint.transform.position.x + 0.4f, blueMidPoint.transform.position.y);
                collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(300f, 0f));
                Debug.Log("we gave 1000f force");

            }
            if (portalGun.attachedObjBlue.name.Equals("rightWall"))
            {

                Debug.Log("SADIJASDIOJASIJDOAISOJD");
                collision.transform.position = new Vector2(blueMidPoint.transform.position.x - 0.4f , blueMidPoint.transform.position.y);
                collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(-400f, 0f));
                Debug.Log("GOOBY PLEASE");
            }
            if (portalGun.attachedObjBlue.name.Equals("topWall"))
            {

                Debug.Log("SADIJASDIOJASIJDOAISOJD");
                collision.transform.position = new Vector2(blueMidPoint.transform.position.x , blueMidPoint.transform.position.y -0.4f);
                collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -500f));

            }

            Debug.Log("lastCond");
            collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            collision.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
            collision.gameObject.layer = 2;


        }

    }
}
