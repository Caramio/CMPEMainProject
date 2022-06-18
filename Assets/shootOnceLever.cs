using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootOnceLever : MonoBehaviour
{

    public GameObject bulletPrefab;

    public GameObject deathAnim;

    public float bulletVelo;

    public bool turretDied = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          
    }



    public void shootOnce()
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
