using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBlueFireBall : MonoBehaviour
{
    GameObject astroBuddy;

    public Vector3 targetLocation;

    void Start()
    {
        if (GameObject.Find("AstroStay") != null)
        {
            astroBuddy = GameObject.Find("AstroStay");

        }
    }

    // Update is called once per frame
    void Update()
    {

       // this.GetComponent<Rigidbody2D>().velocity = (targetLocation * 0.5f);
        this.GetComponent<Rigidbody2D>().velocity = (targetLocation).normalized * 10f;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name.Contains("Wall") || collision.collider.name.Contains("Floor") || collision.collider.name.Contains("Platform"))
        {
            Debug.Log("sdf23333333333333333333333333333");
            Destroy(this.gameObject);

        }
    }

    
}
