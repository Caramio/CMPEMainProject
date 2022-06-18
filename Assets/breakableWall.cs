using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakableWall : MonoBehaviour
{
    public GameObject impactAnimation;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("bullet"))
        {
            if (this.gameObject.activeInHierarchy)
            {
                Instantiate(impactAnimation, this.transform.position, this.transform.rotation);
                Instantiate(impactAnimation, new Vector2(this.transform.position.x - 0.6f ,this.transform.position.y), this.transform.rotation);
                Instantiate(impactAnimation, new Vector2(this.transform.position.x + 0.6f, this.transform.position.y), this.transform.rotation);
            }

            this.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("playerFireBall"))
        {

            Instantiate(impactAnimation, this.transform.position, this.transform.rotation);
            Instantiate(impactAnimation, new Vector2(this.transform.position.x - 0.6f, this.transform.position.y), this.transform.rotation);
            Instantiate(impactAnimation, new Vector2(this.transform.position.x + 0.6f, this.transform.position.y), this.transform.rotation);

            Destroy(collision.collider.gameObject);

            this.gameObject.SetActive(false);
        }
    }
}
