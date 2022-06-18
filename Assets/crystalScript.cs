using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crystalScript : MonoBehaviour
{
    GameObject bluePortal, greenPortal;

    public GameObject interactedObj;
    public GameObject interactedObjTwo;
    public GameObject interactedObjThree;

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

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("bullet"))
        {
            Debug.Log("OK");
            this.transform.GetChild(0).GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = 1f;

            if (interactedObj != null)
            {
                if (interactedObj.tag.Contains("Wall") || interactedObj.tag.Contains("Light"))
                {
                    interactedObj.SetActive(!interactedObj.activeInHierarchy);
                }

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

            if(interactedObjTwo != null)
            {
                if (interactedObjTwo.tag.Contains("Wall") || interactedObjTwo.tag.Contains("Light"))
                {
                    interactedObjTwo.SetActive(!interactedObjTwo.activeInHierarchy);
                }

                if (portalGun.attachedObjBlue != null && portalGun.attachedObjGreen != null)
                {
                    if (portalGun.attachedObjBlue.gameObject == interactedObjTwo.gameObject)
                    {
                        bluePortal.transform.position = new Vector2(100f, 100f);
                        bluePortal.GetComponent<SpriteRenderer>().enabled = false;
                    }
                    if (portalGun.attachedObjGreen.gameObject == interactedObjTwo.gameObject)
                    {
                        greenPortal.transform.position = new Vector2(100f, 100f);
                        greenPortal.GetComponent<SpriteRenderer>().enabled = false;
                    }
                }
            }


            if (interactedObjThree != null)
            {
                if (interactedObjThree.tag.Contains("Wall") || interactedObjThree.tag.Contains("Light"))
                {
                    interactedObjThree.SetActive(!interactedObjThree.activeInHierarchy);
                }

                if (portalGun.attachedObjBlue != null && portalGun.attachedObjGreen != null)
                {
                    if (portalGun.attachedObjBlue.gameObject == interactedObjThree.gameObject)
                    {
                        bluePortal.transform.position = new Vector2(100f, 100f);
                        bluePortal.GetComponent<SpriteRenderer>().enabled = false;
                    }
                    if (portalGun.attachedObjGreen.gameObject == interactedObjThree.gameObject)
                    {
                        greenPortal.transform.position = new Vector2(100f, 100f);
                        greenPortal.GetComponent<SpriteRenderer>().enabled = false;
                    }
                }
            }




        }













        }


}
