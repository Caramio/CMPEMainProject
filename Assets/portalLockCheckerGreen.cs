﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalLockCheckerGreen : MonoBehaviour
{

    public static bool greenOverlapsBlue;

    void Start()
    {




    }


    void Update()
    {







    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name.Equals("bluePortal"))
        {
            greenOverlapsBlue = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("bluePortal"))
        {
            greenOverlapsBlue = false;
        }
    }
}
