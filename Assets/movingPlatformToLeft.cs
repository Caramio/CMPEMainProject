using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatformToLeft : MonoBehaviour
{
    bool backUpChecker = false;

    bool wentLeft = false;

    public GameObject platformRightLimit;

    float startXpos;

    public float movementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        startXpos = this.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        movePlatformLeft();
        movePlatformRight();
        movePlatformBack();
    }

    void movePlatformRight()
    {
        if (wentLeft == true)
        {
            
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(movementSpeed, 0f);
            /*
               this.GetComponent<Rigidbody2D>().transform.position = new Vector2(this.GetComponent<Rigidbody2D>().position.x + (movementSpeed * Time.deltaTime),
                this.GetComponent<Rigidbody2D>().transform.position.y);
            */

        }


    }

    void movePlatformLeft()
    {
        if (wentLeft == false)
        {
            
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-movementSpeed, 0f);
            /*
            this.GetComponent<Rigidbody2D>().transform.position = new Vector2(this.GetComponent<Rigidbody2D>().position.x - (movementSpeed * Time.deltaTime),
                this.GetComponent<Rigidbody2D>().transform.position.y);
            */

        }


    }

    void movePlatformBack()
    {

        
        if (this.transform.position.x + -0.1f >= startXpos)
        {
            wentLeft = false;
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("elevatorTopLimit"))
        {
            
            wentLeft = true;


        }




    }
}
