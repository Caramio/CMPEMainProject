using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leverScript : MonoBehaviour
{
    GameObject bluePortal, greenPortal;

    public GameObject interactedObj;
    public GameObject interactedObjTwo;
    public GameObject interactedObjThree;

    public bool isInRange = false;

    Vector3 startRotation;

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

        startRotation = this.transform.eulerAngles;
    }

    
    void Update()
    {
        if (Time.timeScale == 1)
        {
            pullLever();
        }
    }


    void pullLever()
    {
        // if it is a one interaction lever
        if (this.tag.Equals("oneLever"))
        {
            if (isInRange == true)
            {
                // if i press E and the interacted obj has Wall inside its tag
                if (Input.GetKeyDown("e"))
                {
                    // swap levers rotation
                    if (startRotation.z == 180 || startRotation.z == 0)
                    {
                        this.gameObject.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x + 180f, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
                    }
                    if (startRotation.z == 270)
                    {
                        this.gameObject.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y + 180f, this.transform.eulerAngles.z);
                    }

                    if (interactedObj != null)
                    {
                        if (interactedObj.tag.Contains("Wall"))
                        {
                            // deactive and reactivate the walls
                            if (interactedObj.gameObject.activeSelf == true)
                            {
                                interactedObj.gameObject.SetActive(false);
                            }
                            else if (interactedObj.gameObject.activeSelf == false)
                            {
                                interactedObj.gameObject.SetActive(true);
                            }
                            // if the wall was a portalable wall
                            if (portalGun.attachedObjBlue != null && portalGun.attachedObjGreen != null)
                            {
                                if (portalGun.attachedObjBlue.gameObject == interactedObj.gameObject)
                                {
                                    bluePortal.transform.position = new Vector2(100f, 100f);
                                    bluePortal.GetComponent<SpriteRenderer>().enabled = false;
                                }
                                if (portalGun.attachedObjGreen.gameObject == interactedObj.gameObject)
                                {
                                    greenPortal.transform.position = new Vector2(100f, 100f);
                                    greenPortal.GetComponent<SpriteRenderer>().enabled = false;
                                }
                            }
                        }
                        // if the interacted obj is a turret , destroy it
                        if (interactedObj.tag.Contains("turret"))
                        {
                            if (interactedObj.GetComponent<shootBullet>().turretDied == false)
                            {
                                interactedObj.GetComponent<shootBullet>().turretDied = true;
                            }
                            else if (interactedObj.GetComponent<shootBullet>().turretDied == true)
                            {
                                interactedObj.GetComponent<shootBullet>().turretDied = false;
                            }
                        }
                    }
                    // end of if i press E statement
                }

            }
        }

        // if the lever involves more than one interaction
        if (this.tag.Equals("twoLever"))
        {
            if (isInRange == true)
            {
                // if i press E and the interacted obj has Wall inside its tag
                if (Input.GetKeyDown("e"))
                {
                    // swap levers rotation
                    if (startRotation.z == 180 || startRotation.z == 0)
                    {
                        this.gameObject.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x + 180f, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
                    }
                    if (startRotation.z == 270)
                    {
                        this.gameObject.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y + 180f, this.transform.eulerAngles.z);
                    }

                    if (interactedObj != null && interactedObjTwo != null)
                    {
                        if (interactedObj.tag.Contains("Wall") && interactedObjTwo.tag.Contains("Wall"))
                        {
                            // deactive and reactivate the walls
                            
                                interactedObj.gameObject.SetActive(!interactedObj.activeInHierarchy);
                                interactedObjTwo.gameObject.SetActive(!interactedObjTwo.activeInHierarchy);
                            
                            
                            // if the wall was a portalable wall
                            if (portalGun.attachedObjBlue != null && portalGun.attachedObjGreen != null)
                            {
                                if (portalGun.attachedObjBlue.gameObject == interactedObj.gameObject || portalGun.attachedObjBlue.gameObject == interactedObjTwo.gameObject)
                                {
                                    bluePortal.transform.position = new Vector2(100f, 100f);
                                    bluePortal.GetComponent<SpriteRenderer>().enabled = false;
                                }
                                if (portalGun.attachedObjGreen.gameObject == interactedObj.gameObject || portalGun.attachedObjGreen.gameObject == interactedObjTwo.gameObject)
                                {
                                    greenPortal.transform.position = new Vector2(100f, 100f);
                                    greenPortal.GetComponent<SpriteRenderer>().enabled = false;
                                }
                            }
                        }
                        // if the interacted obj is a turret , destroy it --- TURRET MUST BE INTERACTED OBJ , NOT SECOND ONE
                        if (interactedObj.tag.Contains("turret"))
                        {
                            if (interactedObj.GetComponent<shootBullet>().turretDied == false)
                            {
                                interactedObj.GetComponent<shootBullet>().turretDied = true;
                            }
                            else if (interactedObj.GetComponent<shootBullet>().turretDied == true)
                            {
                                interactedObj.GetComponent<shootBullet>().turretDied = false;
                            }
                        }
                    }
                    // end of if i press E statement
                }

            }
        }


        // if the lever involves THREE INTERACTIONS TEST HERE
        if (this.tag.Equals("threeLever"))
        {
            if (isInRange == true)
            {
                // if i press E and the interacted obj has Wall inside its tag
                if (Input.GetKeyDown("e"))
                {
                    // swap levers rotation
                    if (startRotation.z == 180 || startRotation.z == 0)
                    {
                        this.gameObject.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x + 180f, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
                    }
                    if (startRotation.z == 270)
                    {
                        this.gameObject.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y + 180f, this.transform.eulerAngles.z);
                    }

                    if (interactedObj != null && interactedObjTwo != null)
                    {
                        if (interactedObj.tag.Contains("Wall") && interactedObjTwo.tag.Contains("Wall") && interactedObjThree.tag.Contains("Wall"))
                        {
                            // deactive and reactivate the walls
                            
                                interactedObj.gameObject.SetActive(!interactedObj.gameObject.activeInHierarchy);
                                interactedObjTwo.gameObject.SetActive(!interactedObjTwo.gameObject.activeInHierarchy);
                                interactedObjThree.gameObject.SetActive(!interactedObjThree.gameObject.activeInHierarchy);
                            
                           
                            // if the wall was a portalable wall
                            if (portalGun.attachedObjBlue != null && portalGun.attachedObjGreen != null)
                            {
                                if (portalGun.attachedObjBlue.gameObject == interactedObj.gameObject || portalGun.attachedObjBlue.gameObject == interactedObjTwo.gameObject ||
                                    portalGun.attachedObjBlue.gameObject == interactedObjThree.gameObject)
                                {
                                    bluePortal.transform.position = new Vector2(100f, 100f);
                                    bluePortal.GetComponent<SpriteRenderer>().enabled = false;
                                }
                                if (portalGun.attachedObjGreen.gameObject == interactedObj.gameObject || portalGun.attachedObjGreen.gameObject == interactedObjTwo.gameObject ||
                                    portalGun.attachedObjGreen.gameObject == interactedObjThree.gameObject)
                                {
                                    greenPortal.transform.position = new Vector2(100f, 100f);
                                    greenPortal.GetComponent<SpriteRenderer>().enabled = false;
                                }
                            }
                        }
                        // if the interacted obj is a turret , destroy it --- TURRET MUST BE INTERACTED OBJ , NOT SECOND ONE
                        if (interactedObj.tag.Contains("turret"))
                        {
                            if (interactedObj.GetComponent<shootBullet>().turretDied == false)
                            {
                                interactedObj.GetComponent<shootBullet>().turretDied = true;
                            }
                            else if (interactedObj.GetComponent<shootBullet>().turretDied == true)
                            {
                                interactedObj.GetComponent<shootBullet>().turretDied = false;
                            }
                        }
                    }
                    // end of if i press E statement
                }

            }
        }



    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            isInRange = false;
        }
    }
}
