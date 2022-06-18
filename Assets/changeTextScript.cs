using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeTextScript : MonoBehaviour
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
        
        
        
    }
}
