using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalMover : MonoBehaviour
{

    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (portalGun.attachedObjBlue != null)
        {
            movePortalWithWall();
        }
    }




    void movePortalWithWall()
    {

        if(portalGun.attachedObjBlue.GetComponent<movingWall>() != null && portalGun.attachedObjBlue.tag.Equals("bottomWall"))
        {

            this.transform.position = new Vector2(portalGun.attachedObjBlue.transform.position.x, portalGun.attachedObjBlue.transform.position.y + 0.3f);

        }

        if (portalGun.attachedObjBlue.GetComponent<movingWall>() != null && portalGun.attachedObjBlue.tag.Equals("topWall"))
        {

            this.transform.position = new Vector2(portalGun.attachedObjBlue.transform.position.x, portalGun.attachedObjBlue.transform.position.y - 0.05f);

        }
    }
}
