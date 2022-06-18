using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingWall : MonoBehaviour
{
    // Method to check if wall is moving or not
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (portalGun.attachedObjGreen != null || portalGun.attachedObjBlue != null)
        {
            if (portalGun.attachedObjGreen.gameObject == this.gameObject || portalGun.attachedObjBlue == this.gameObject)
            {

                this.GetComponent<portallableWall>().enabled = false;

            }
            else
            {

                this.GetComponent<portallableWall>().enabled = true;

            }
        }


    }
}
