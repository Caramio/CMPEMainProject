using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightChanger : MonoBehaviour
{

    public GameObject globalLight;
    public float lightIntensity;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            // change the global light intensity
            globalLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = lightIntensity;

        }
    }
}
