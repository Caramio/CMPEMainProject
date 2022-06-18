using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalTelePoint : MonoBehaviour
{

    GameObject bluePortal;
    GameObject greenPortal;

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

    
    void Update()
    {
        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag.Equals("Player"))
        {

            collision.gameObject.layer = 2;
            collision.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

            collision.transform.position = new Vector2(greenPortal.transform.position.x, greenPortal.transform.position.y + 2f);

            collision.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Default";

            Debug.Log("Teleported");
            
           



        }



    }
}
