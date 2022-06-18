using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCannonFire : MonoBehaviour
{
    public Transform firePoint;

    public GameObject fireBall;

    GameObject astroBuddy;

    bool enteredTurret = false;

    Vector3 targetedPoint;

    

    bool isInRange = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enterTurret();
        playerShootFire();
    }

    void enterTurret()
    {

        if (Input.GetKeyDown("e") && isInRange && enteredTurret == false)
        {
            astroBuddy.GetComponent<playerMovement>().ableToMove = false;
            enteredTurret = true;
        }
        else if(Input.GetKeyDown("e") && isInRange && enteredTurret == true)
        {
            astroBuddy.GetComponent<playerMovement>().ableToMove = true;
            enteredTurret = false;

        }

        

    }

    void playerShootFire()
    {


        if (playerMovement.fireballAmount > 0 && enteredTurret)
        {

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                playerMovement.fireballAmount -= 1;

               
                GameObject fireObj = Instantiate(fireBall, firePoint.transform.position, fireBall.transform.rotation);
                targetedPoint = (Camera.main.ScreenToWorldPoint(Input.mousePosition));
                targetedPoint.z = 0f;
                fireObj.GetComponent<moveBlueFireBall>().targetLocation = targetedPoint - this.transform.position;
                   


            }

        }



    }





    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            astroBuddy = collision.gameObject;
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
