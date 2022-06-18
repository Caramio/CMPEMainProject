using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalEntrance : MonoBehaviour
{

    public Camera currentCamera;

    public GameObject closedWall , finalBoss , firstCrate , secondCrate ,globalLight;

    bool playerEnteredZone = false;



    public bool levelStarted = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (globalLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity < 1 && playerEnteredZone)
        {
            gradualLightIncrease();
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            if (levelStarted == false)
            {
                closedWall.SetActive(true);

                finalBoss.SetActive(true);

                firstCrate.SetActive(true);

                secondCrate.SetActive(true);

               
                playerEnteredZone = true;

                currentCamera.orthographicSize = 10f;

                levelStarted = true;
            }


        }
    }

    void gradualLightIncrease()
    {
        if (globalLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity < 1)
        {
            globalLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity =
                Mathf.Lerp(globalLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity, 1f, 0.99999f * Time.deltaTime);
            
        }

    }
}
