using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalLocCheckerBlue : MonoBehaviour
{

    public static bool blueOverlapsGreen;

    void Start()
    {

      


    }

    
    void Update()
    {

        
        
        



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name.Equals("greenPortal")){
            blueOverlapsGreen = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("bluePortal"))
        {
            blueOverlapsGreen = false;
        }
    }







}
