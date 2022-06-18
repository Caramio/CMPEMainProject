using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class usefulMethods : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // method to not create portals on eachother within the same wall
    public bool inBetween(float maxDifference, float first, float second)
    {
        if (Mathf.Abs(first - second) >= maxDifference)
        {
            return false;

        }
        else
        {
            return true;
        }


    }




}
