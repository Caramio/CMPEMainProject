using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletShootLever : MonoBehaviour
{

    public GameObject attachedTurret;

    float timerStart;
    float timerEnd = 3f;

    bool isInRange = false;

    Vector3 startRotation;

    void Start()
    {
        startRotation = this.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        // if input is e , shoot a bullet

        timerStart += Time.deltaTime;
        
        if (Input.GetKeyDown("e") && timerStart >= timerEnd && isInRange == true)
        {
            if (startRotation.z == 180 || startRotation.z == 0)
            {
                this.gameObject.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x + 180f, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
            }
            if (startRotation.z == 270)
            {
                this.gameObject.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y + 180f, this.transform.eulerAngles.z);
            }

            attachedTurret.GetComponent<shootOnceLever>().shootOnce();
            timerStart = 0f;


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
