using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevatorHandler : MonoBehaviour
{
    bool backUpChecker = false;

    bool wentUp = false;

    public GameObject elevatorTopLimit;

    public float elevatorSpeed;

    float startYpos;
    
    void Start()
    {
        startYpos = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        moveElevatorUp();
        moveElevatorDown();
        elevatorBackUp();
    }

    
    
    
    void moveElevatorUp()
    {
        if (wentUp == false)
        {

            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, elevatorSpeed);

            /*
            this.GetComponent<Rigidbody2D>().transform.position = new Vector2(this.GetComponent<Rigidbody2D>().transform.position.x,
                this.GetComponent<Rigidbody2D>().transform.position.y + (Time.deltaTime * elevatorSpeed));
            */

        }
       

    }

    void moveElevatorDown()
    {
        if (wentUp == true)
        {
            
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -elevatorSpeed);
            
            /*this.GetComponent<Rigidbody2D>().transform.position = new Vector2(this.GetComponent<Rigidbody2D>().transform.position.x,
                this.GetComponent<Rigidbody2D>().transform.position.y - (Time.deltaTime * elevatorSpeed));
            */

        }


    }

    void elevatorBackUp()
    {
        
            
            if (this.transform.position.y - 0.1f <= startYpos)
            {
            wentUp = false;
            }
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("elevatorTopLimit"))
        {
            
            wentUp = true;
            
            
        }



        if (collision.tag.Equals("Player"))
        {
            // send the elevator back up if it crushes the player
            /*
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(this.gameObject.GetComponent<Rigidbody2D>().velocity.x,
                -this.gameObject.GetComponent<Rigidbody2D>().velocity.y);
            */
        }


    }


}
