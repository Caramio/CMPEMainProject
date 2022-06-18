using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossMover : MonoBehaviour
{
    bool wentRight = false;

    public float movementSpeed;

    float startXpos;


    // Start is called before the first frame update
    void Start()
    {
        startXpos = this.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        movePlatformRight();
        movePlatformLeft();
        movePlatformBack();

    }

    void movePlatformRight()
    {
        if (wentRight == false)
        {

            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(movementSpeed, 0f);
            /*
            this.GetComponent<Rigidbody2D>().transform.position = new Vector2(this.GetComponent<Rigidbody2D>().transform.position.x + (movementSpeed * Time.deltaTime),
                this.GetComponent<Rigidbody2D>().transform.position.y);
            */

        }


    }

    void movePlatformLeft()
    {
        if (wentRight == true)
        {

            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-movementSpeed, 0f);
            /*
               this.GetComponent<Rigidbody2D>().transform.position = new Vector2(this.GetComponent<Rigidbody2D>().transform.position.x - (movementSpeed * Time.deltaTime),
                this.GetComponent<Rigidbody2D>().transform.position.y);
            */

        }


    }

    void movePlatformBack()
    {


        if (this.transform.position.x - 0.1f <= startXpos)
        {
            wentRight = false;
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("elevatorTopLimit"))
        {

            wentRight = true;


        }

    }
}
