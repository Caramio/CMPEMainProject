using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopMovingPlatformLever : MonoBehaviour
{
    public GameObject movingWall;

    bool isMoving = true;

    bool isInRange = false;

    Vector2 startWallVelo;

    Vector3 startRotation;
    void Start()
    {
        startRotation = this.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e") && isInRange == true)
        {
            
            if (startRotation.z == 180 || startRotation.z == 0)
            {
                this.gameObject.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x + 180f, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
            }
            if (startRotation.z == 270)
            {
                this.gameObject.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y + 180f, this.transform.eulerAngles.z);
            }
            startWallVelo = movingWall.GetComponent<Rigidbody2D>().velocity;

            if(isMoving == true)
            {
                movingWall.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                isMoving = false;
            }
            else if(isMoving == false)
            {
                movingWall.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                isMoving = true;
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
