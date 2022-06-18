using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballSpawn : MonoBehaviour
{
    public float timerStart, timerEnd;

    public GameObject spikyBall;
    void Start()
    {
        
    }

    
    void Update()
    {
        timerStart += Time.deltaTime;

        if (timerStart >= timerEnd)
        {
            spawnBall();
            timerStart = 0f;
        }

    }

    void spawnBall()
    {

        
            Instantiate(spikyBall, this.transform.position, this.transform.rotation);
               
        
    }
}
