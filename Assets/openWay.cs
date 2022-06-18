using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openWay : MonoBehaviour
{
    public GameObject openedWall;
    GameObject greenPortal, bluePortal;
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
            Destroy(openedWall);
            
            if (portalGun.attachedObjBlue != null && portalGun.attachedObjGreen != null)
            {
                if (portalGun.attachedObjBlue.name == openedWall.gameObject.name)
                {
                    bluePortal.transform.position = new Vector2(100f, 100f);
                    bluePortal.GetComponent<SpriteRenderer>().enabled = false;
                }
                if (portalGun.attachedObjGreen.name == openedWall.gameObject.name)
                {
                    greenPortal.transform.position = new Vector2(100f, 100f);
                    greenPortal.GetComponent<SpriteRenderer>().enabled = false;
                }
            }

        }
    }
}
