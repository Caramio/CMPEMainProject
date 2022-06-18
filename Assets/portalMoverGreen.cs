using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalMoverGreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (portalGun.attachedObjGreen != null)
        {
            movePortalWithWall();
        }
    }


    void movePortalWithWall()
    {

        if (portalGun.attachedObjGreen.GetComponent<movingWall>() != null && portalGun.attachedObjGreen.tag.Equals("bottomWall"))
        {

            this.transform.position = new Vector2(portalGun.attachedObjGreen.transform.position.x, portalGun.attachedObjGreen.transform.position.y + 0.3f);

        }

        if (portalGun.attachedObjGreen.GetComponent<movingWall>() != null && portalGun.attachedObjGreen.tag.Equals("topWall"))
        {

            this.transform.position = new Vector2(portalGun.attachedObjGreen.transform.position.x, portalGun.attachedObjGreen.transform.position.y - 0.05f);

        }
    }
}
