using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightSwitch : MonoBehaviour
{

    public GameObject lightOne, lightTwo, lightThree, lightFour;

    bool isInRange;

    Vector3 startRotation;


    void Start()
    {
        startRotation = this.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("e") && isInRange)
        {
            // swap levers rotation
            if (startRotation.z == 180 || startRotation.z == 0)
            {
                this.gameObject.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x + 180f, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
            }
            if (startRotation.z == 270)
            {
                this.gameObject.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y + 180f, this.transform.eulerAngles.z);
            }

            if (this.tag.Equals("oneLight")) {
                if (lightOne != null)
                {
                    if (lightOne.tag.Contains("Light"))
                    {
                        

                        lightOne.gameObject.SetActive(!lightOne.activeInHierarchy);

                    }
                }


            }

            if (this.tag.Equals("twoLight"))
            {

                if (lightOne != null && lightTwo != null)
                {
                    if (lightOne.tag.Contains("Light"))
                    {

                        
                        lightOne.gameObject.SetActive(!lightOne.activeInHierarchy);
                        lightTwo.gameObject.SetActive(!lightTwo.activeInHierarchy);

                    }
                }
            }


            if (this.tag.Equals("threeLight"))
            {

                if (lightOne != null && lightTwo != null && lightThree != null)
                {
                    if (lightOne.tag.Contains("Light"))
                    {

                        
                        lightOne.gameObject.SetActive(!lightOne.activeInHierarchy);
                        lightTwo.gameObject.SetActive(!lightTwo.activeInHierarchy);
                        lightThree.gameObject.SetActive(!lightThree.activeInHierarchy);

                    }
                }
            }

            if (this.tag.Equals("fourLight"))
            {

                if (lightOne != null && lightTwo != null && lightThree != null && lightFour != null)
                {
                    if (lightOne.tag.Contains("Light"))
                    {


                        lightOne.gameObject.SetActive(!lightOne.activeInHierarchy);
                        lightTwo.gameObject.SetActive(!lightTwo.activeInHierarchy);
                        lightThree.gameObject.SetActive(!lightThree.activeInHierarchy);
                        lightFour.gameObject.SetActive(!lightFour.activeInHierarchy);

                    }
                }
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
