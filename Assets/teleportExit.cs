﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportExit : MonoBehaviour

{

    
    // Start is called before the first frame update
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
            
            collision.gameObject.layer = 8;
            collision.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Teleporting";
            
        }
        
    }

    
}
