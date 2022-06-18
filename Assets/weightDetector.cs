using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weightDetector : MonoBehaviour
{
    GameObject bluePortal, greenPortal;

    Vector2 startCollSize;
    Vector3 startObjSize;

    GameObject collisionEnteredObj;

    public GameObject interactedObj;
    public GameObject interactedObjTwo;

    bool objectPlayerEntered = false , objectBoxEntered = false;

    bool objChangedObjInitialStateOne, objChangedObjInitialStateTwo;

    bool doOnce = false;
    // Start is called before the first frame update
    void Start()
    {
        startCollSize = this.GetComponent<BoxCollider2D>().size;
        startObjSize = this.transform.localScale;

        objChangedObjInitialStateOne = interactedObj.activeInHierarchy;
        objChangedObjInitialStateTwo = interactedObj.activeInHierarchy;


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
        this.GetComponent<BoxCollider2D>().size = transform.InverseTransformVector(0.9f, 0.3f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            objectPlayerEntered = true;
        }

        if (collision.tag.Equals("pushableBox"))
        {
            objectBoxEntered = true;
        }

        /*

        if (collisionEnteredObj != null)
        {

            if (collision.tag.Equals("pushableBox") || collision.tag.Equals("Player"))
            {

                

                if (interactedObj != null && objChangedObjInitialStateOne)
                {
                    interactedObj.SetActive(!interactedObj.activeInHierarchy);
                    objChangedObjInitialStateOne = !objChangedObjInitialStateOne;
                }


                if (interactedObjTwo != null && objChangedObjInitialStateTwo)
                {
                    interactedObjTwo.SetActive(!interactedObjTwo.activeInHierarchy);
                    objChangedObjInitialStateTwo = !objChangedObjInitialStateTwo;
                }


            }
        }

        */


    }
    /*
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        collisionEnteredObj = collision.gameObject;

        if (collisionEnteredObj != null)
        {

            if (collision.tag.Equals("pushableBox") || collision.tag.Equals("Player"))
            {



                if (interactedObj != null && objChangedObjInitialStateOne)
                {
                    interactedObj.SetActive(!interactedObj.activeInHierarchy);
                    objChangedObjInitialStateOne = !objChangedObjInitialStateOne;
                }


                if (interactedObjTwo != null && objChangedObjInitialStateTwo)
                {
                    interactedObjTwo.SetActive(!interactedObjTwo.activeInHierarchy);
                    objChangedObjInitialStateTwo = !objChangedObjInitialStateTwo;
                }


            }
        }
        

    }
    */
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (objectPlayerEntered == true || objectBoxEntered == true) {
            {
                if (doOnce == false)
                {

                    if (interactedObj != null)
                    {
                        interactedObj.SetActive(!interactedObj.activeInHierarchy);
                    }


                    if (interactedObjTwo != null)
                    {
                        interactedObjTwo.SetActive(!interactedObjTwo.activeInHierarchy);
                    }

                    doOnce = true;
                }
            }


        }
        
    }





    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            if (interactedObj != null)
            {
                interactedObj.SetActive(!interactedObj.activeInHierarchy);
            }
            if (interactedObjTwo != null)
            {
                interactedObjTwo.SetActive(!interactedObjTwo.activeInHierarchy);
            }

            objectPlayerEntered = false;
            doOnce = false;
        }

        if (collision.tag.Equals("pushableBox"))
        {
            if (interactedObj != null)
            {
                interactedObj.SetActive(!interactedObj.activeInHierarchy);
            }
            if (interactedObjTwo != null)
            {
                interactedObjTwo.SetActive(!interactedObjTwo.activeInHierarchy);
            }

            objectBoxEntered = false;
            doOnce = false;
        }


        /*
        if (interactedObj != null || interactedObjTwo != null)
        {
            if (collision.tag.Equals("Player") || collision.tag.Equals("pushableBox"))
            {

                if (collision.gameObject != null)
                {
                    if (collision.gameObject == collisionEnteredObj.gameObject)
                    {

                        if (interactedObj != null && !objChangedObjInitialStateOne)
                        {
                            interactedObj.SetActive(!interactedObj.activeInHierarchy);
                            objChangedObjInitialStateOne = !objChangedObjInitialStateOne;
                        }
                        if (interactedObjTwo != null && !objChangedObjInitialStateTwo)
                        {
                            interactedObjTwo.SetActive(!interactedObjTwo.activeInHierarchy);
                            objChangedObjInitialStateTwo = !objChangedObjInitialStateTwo;
                        }

                    }
                }

                collisionEnteredObj = null;

            }

            
        }
        */
    }
        
}
