using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootBullet : MonoBehaviour
{
    public GameObject bulletPrefab;

    //death animation
    public GameObject deathAnim;

    //death condition
    public bool turretDied = false;

 
    // interval for the bullet firing
    float shootTimerStart = 0f;
    public float shootTimerEnd = 1f;


    //speed for bullets
    public float bulletVelo;
    void Start()
    {
        
    }

    
    void Update()
    {

        if (turretDied == false)
        {
            shootMissile();
        }

    }



    void shootMissile()
    {
        shootTimerStart += Time.deltaTime;

        if (shootTimerStart >= shootTimerEnd)
        {
            {
                
                GameObject shotBullet = Instantiate(bulletPrefab, this.transform.GetChild(0).transform.position, this.transform.rotation);
                // shooting to a specific direction depending on the rotation of my turret
                if (this.transform.rotation.y == 0f)
                {
                    
                    shotBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletVelo, 0f);
                }
                else
                {
                    
                    shotBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-bulletVelo, 0f);
                }

            }
            shootTimerStart = 0f;
        }




    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("bullet"))
        {
            turretDied = true;
            Instantiate(deathAnim, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);

        }
    }

}
