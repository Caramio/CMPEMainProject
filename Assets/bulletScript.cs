using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour


{

    
    public bool positiveYVals;
    public bool positiveXVals;
    

    
    

    public GameObject impactAnimation;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        velocityCalcBullet();
    }


    public void velocityCalcBullet()
    {

        if(this.GetComponent<Rigidbody2D>().velocity.y > 0)
        {
            positiveYVals = true;
        }
        if (this.GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            positiveYVals = false;
        }
        if (this.GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            positiveXVals = true;
        }
        if (this.GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            positiveXVals = false;
        }


    }


    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag.Contains("Wall"))
        {
            Instantiate(impactAnimation, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }

        if (collision.name.Equals("midPoint"))
        {
            Debug.Log("dfogkopdfgkfpd");
        }


        if (collision.tag.Equals("turret"))
        {
            Instantiate(impactAnimation, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
            
        }

        if (collision.tag.Equals("pushableBox"))
        {
            Instantiate(impactAnimation, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);

        }

        



    }
}
