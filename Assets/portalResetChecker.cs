using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalResetChecker : MonoBehaviour
{
    public static bool canResetPortal = true;
    public static bool canResetPortalBox = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {

            canResetPortal = false;

        }

        if (collision.tag.Equals("pushableBox"))
        {
            canResetPortalBox = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {

            canResetPortal = false;

        }

        if (collision.tag.Equals("pushableBox"))
        {
            canResetPortalBox = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {

            canResetPortal = true;

        }

        if (collision.tag.Equals("pushableBox"))
        {
            canResetPortalBox = true;
        }

    }
}
