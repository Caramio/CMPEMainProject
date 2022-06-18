using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerCheckpoint : MonoBehaviour
{
    int currentScene;

    GameObject playerObj;

    bool reachedPoint = false;

    
    public static GameObject latestCheckpointOne;

    void Start()
    {
       
        DontDestroyOnLoad(this.gameObject);

        if (GameObject.Find("AstroStay") != null)
        {
            playerObj = GameObject.Find("AstroStay");
            
        }

        // start the player from checkpoint
        if (latestCheckpointOne != null)
        {
            
            playerObj.transform.position = latestCheckpointOne.transform.position;
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
            latestCheckpointOne = this.gameObject;
        }
    }
}
