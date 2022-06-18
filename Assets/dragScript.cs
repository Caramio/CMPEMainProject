using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragScript : MonoBehaviour
{

    GameObject bluePortal, greenPortal;

    public static bool objCurrentCarry = false;

    bool isInRange = false;

    bool carryingObj = false;

    GameObject wizardPlayer;

    float pushTimerStart , pushTimerEnd = 3f;
    

    void Start()
    {

        if (GameObject.Find("bluePortal") != null)
        {
            bluePortal = GameObject.Find("bluePortal");
            

        }
        if (GameObject.Find("greenPortal") != null)
        {
            greenPortal = GameObject.Find("greenPortal");
            

        }

    }

    // Update is called once per frame
    void Update()
    {
        pushTimerStart += Time.deltaTime;

        
            if (carryingObj == true)
            {
                if (wizardPlayer != null)
                {
                //this.transform.GetComponentInParent<Rigidbody2D>().transform.position = wizardPlayer.transform.GetChild(4).transform.position;
                //this.transform.GetComponentInParent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                if (pushTimerStart >= pushTimerEnd)
                {
                    if (wizardPlayer.transform.eulerAngles.y == 180f)
                    {
                        this.transform.GetComponentInParent<Rigidbody2D>().AddForce(new Vector2(500f, 0f));
                    }
                    if (wizardPlayer.transform.eulerAngles.y == 0f)
                    {
                        this.transform.GetComponentInParent<Rigidbody2D>().AddForce(new Vector2(-500f, 0f));
                    }
                    carryingObj = false;

                    pushTimerStart = 0f;
                }


                }

            }
            
        

        if (Input.GetKeyDown("q") && isInRange)
        {
            Debug.Log("sdpofksdpfoksdfpodskfopkdsfopksdp 214kj29014j9210421");
            if (carryingObj == false)
            {
                resetPortalScript();

                objCurrentCarry = true;

                carryingObj = true;
            }
            else if(carryingObj == true)
            {
                resetPortalScript();

                objCurrentCarry = false;
                this.transform.GetComponentInParent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                carryingObj = false;
                
                
            }
        }
        

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            wizardPlayer = collision.gameObject;
            isInRange = true;


        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            wizardPlayer = null;
            isInRange = false;
        }
    }

    public void resetPortalScript()
    {
        
            portalGun.attachedObjBlue = null;
            portalGun.attachedObjGreen = null;

            bluePortal.transform.position = new Vector2(150f, 150f);
            greenPortal.transform.position = new Vector2(-150f, -150f);

        portalGun.ableToOpenBlue = true;
        portalGun.ableToOpenGreen = true;

            greenPortal.GetComponent<SpriteRenderer>().enabled = false;
            bluePortal.GetComponent<SpriteRenderer>().enabled = false;

            portalTeleportBlue.enteredBlue = false;
            portalTeleportGreen.enteredGreen = false;

            portalTeleportBlue.enteredBlueForBox = false;
            portalTeleportGreen.enteredGreenForBox = false;
        
    }

}
