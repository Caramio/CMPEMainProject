using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPointTutorial : MonoBehaviour
{
    int currentScene;

    GameObject playerObj;

    bool reachedPoint = false;


    public static GameObject latestCheckpointTutorial;

    void Start()
    {

        DontDestroyOnLoad(this.gameObject);

        if (GameObject.Find("AstroStay") != null)
        {
            playerObj = GameObject.Find("AstroStay");

        }

        // start the player from checkpoint
        if (latestCheckpointTutorial != null)
        {

            playerObj.transform.position = latestCheckpointTutorial.transform.position;
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
            latestCheckpointTutorial = this.gameObject;
        }
    }

}
