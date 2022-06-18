using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollower : MonoBehaviour
{
    public Transform cameraObj;
    public Camera thisCamera;
    public GameObject cameraHolder;

    GameObject playerObj;

    float playerXCord;
    float playerYCord;

    bool isFixedCam = true;


    void Start()
    {


    }



    private void Update()
    {
        // assigning variables needed to perform the camera follow when the player is in the scene that the current camera exists in
        if (playerMovement.thisPlayer != null)
        {
            playerObj = playerMovement.thisPlayer;
            playerXCord = playerObj.transform.position.x;
            playerYCord = playerObj.transform.position.y;
        }


        if (Input.GetKeyDown(KeyCode.LeftShift) && isFixedCam == true){
            isFixedCam = false;
            
        }
        else if(Input.GetKeyDown(KeyCode.LeftShift) && isFixedCam == false)
        {
            isFixedCam = true;
        }


        


    }

    private void FixedUpdate()
    {

        // following player with the camera
        if (isFixedCam)
        {
            cameraObj.transform.position = new Vector3(Mathf.Lerp((cameraObj.transform.position.x), playerXCord, 0.05f), Mathf.Lerp(cameraObj.transform.position.y, playerYCord, 0.05f), -5f);

            thisCamera.transform.position = cameraObj.transform.position;
        }

        // to look around
        if(isFixedCam == false)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                cameraObj.transform.position = new Vector3(Mathf.Lerp((cameraObj.transform.position.x), playerXCord - 5f, 0.01f),
                    Mathf.Lerp(cameraObj.transform.position.y, playerYCord, 0.05f), -5f);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                cameraObj.transform.position = new Vector3(Mathf.Lerp((cameraObj.transform.position.x), playerXCord + 5f, 0.01f),
                    Mathf.Lerp(cameraObj.transform.position.y, playerYCord, 0.05f), -5f);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                cameraObj.transform.position = new Vector3(Mathf.Lerp((cameraObj.transform.position.x), playerXCord , 0.01f),
                    Mathf.Lerp(cameraObj.transform.position.y, playerYCord + 5f, 0.05f), -5f);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                cameraObj.transform.position = new Vector3(Mathf.Lerp((cameraObj.transform.position.x), playerXCord , 0.01f),
                    Mathf.Lerp(cameraObj.transform.position.y , playerYCord - 5f, 0.05f), -5f);
            }

           


        }

    }
}

