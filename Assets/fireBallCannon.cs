using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBallCannon : MonoBehaviour
{
    public GameObject fireBall;

    public float timerStart, timerEnd;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timerStart += Time.deltaTime;
        if(timerStart >= timerEnd)
        {
            shootFire();
            timerStart = 0f;
        }

    }


    void shootFire()
    {

        Instantiate(fireBall, this.transform.position, fireBall.transform.rotation);


    }

}
