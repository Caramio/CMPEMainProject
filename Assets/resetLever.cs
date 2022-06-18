using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetLever : MonoBehaviour
{

    GameObject bluePortal, greenPortal;

    public GameObject interactedObj;
    public GameObject interactedObjTwo;
    public GameObject interactedObjThree;
    public GameObject interactedObjFour;

    bool activeOne, activeTwo, activeThree,activeFour;

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

        // first active states of the game objects
        if (interactedObj != null)
        {
            activeOne = interactedObj.gameObject.activeInHierarchy;
        }

        if (interactedObjTwo != null)
        {
            activeTwo = interactedObjTwo.gameObject.activeInHierarchy;
        }

        if (interactedObjThree != null)
        {
            activeThree = interactedObjThree.gameObject.activeInHierarchy;
        }
        if (interactedObjFour != null)
        {
            activeFour = interactedObjFour.gameObject.activeInHierarchy;
        }

    }

    // Update is called once per frame
    void Update()
    {
        pullLeverReset();
    }

    void pullLeverReset()
    {
        if (this.tag.Equals("resetLever"))
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
                            // reset the activeness to initial states
                            interactedObj.SetActive(activeOne);
                            interactedObjTwo.SetActive(activeTwo);
                            interactedObjThree.SetActive(activeThree);
                            interactedObjFour.SetActive(activeFour);

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
                    }
                }
            }
        }
    }


    // detect player
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
                    
                

