using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfCancelScript : MonoBehaviour
{
    float timerStart;
    float timerEnd = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timerStart += Time.deltaTime;

        if(timerStart >= timerEnd)
        {
            Destroy(this.gameObject);
        }
        

    }
}
