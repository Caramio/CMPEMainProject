using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cancelPortalLever : MonoBehaviour
{

    GameObject bluePortal, greenPortal;
    // Start is called before the first frame update
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

        // if its a portal cancel lever , clicking it will deactivate your current portals
        if(this.GetComponent<leverScript>().isInRange == true)
        {

            if (Input.GetKeyDown("e"))
            {
                if (bluePortal.GetComponent<SpriteRenderer>().enabled == true)
                {
                    bluePortal.transform.position = new Vector2(100f, 100f);
                    bluePortal.GetComponent<SpriteRenderer>().enabled = false;
                }
                if (greenPortal.GetComponent<SpriteRenderer>().enabled == true)
                {
                    greenPortal.transform.position = new Vector2(100f, 100f);
                    greenPortal.GetComponent<SpriteRenderer>().enabled = false;
                }
            }

        }
    }
}
