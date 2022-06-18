using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPointFour : MonoBehaviour
{
    int currentScene;

    GameObject playerObj;

    bool reachedPoint = false;

    public GameObject boxSpawn;

    public GameObject boxSpawnPointOne, boxSpawnPointTwo, boxSpawnPointThree;

    public static string checkName;


    public static GameObject latestCheckpointFour;

    void Start()
    {

        DontDestroyOnLoad(this.gameObject);

        if (GameObject.Find("AstroStay") != null)
        {
            playerObj = GameObject.Find("AstroStay");

        }

        // start the player from checkpoint
        if (latestCheckpointFour != null)
        {

            playerObj.transform.position = latestCheckpointFour.transform.position;

            if (checkName == this.gameObject.name)
            {
                if (boxSpawnPointOne != null)
                {
                    GameObject box = Instantiate(boxSpawn, boxSpawnPointOne.transform.position, boxSpawn.transform.rotation);
                    if (this.name.Contains("mass"))
                    {
                        box.GetComponent<Rigidbody2D>().mass = 1.8f;
                    }
                }
                if (boxSpawnPointTwo != null)
                {
                    GameObject box = Instantiate(boxSpawn, boxSpawnPointTwo.transform.position, boxSpawnPointTwo.transform.rotation);
                    if (this.name.Contains("mass"))
                    {
                        box.GetComponent<Rigidbody2D>().mass = 1.8f;
                    }
                }

            }
            




        }


    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("latest point is : " + latestCheckpointFour);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            checkName = this.gameObject.name;
            latestCheckpointFour = this.gameObject;
        }
    }
}
