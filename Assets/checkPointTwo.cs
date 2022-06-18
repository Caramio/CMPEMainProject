using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPointTwo : MonoBehaviour
{
    int currentScene;

    GameObject playerObj;

    bool reachedPoint = false;


    public static GameObject latestCheckpointTwo;

    void Start()
    {

        DontDestroyOnLoad(this.gameObject);

        if (GameObject.Find("AstroStay") != null)
        {
            playerObj = GameObject.Find("AstroStay");

        }

        // start the player from checkpoint
        if (latestCheckpointTwo != null)
        {

            playerObj.transform.position = latestCheckpointTwo.transform.position;
        }


    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            latestCheckpointTwo = this.gameObject;
        }
    }
}
