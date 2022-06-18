using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBallScript : MonoBehaviour
{
    GameObject astroBuddy;

    private Vector3 smoothTime = Vector3.zero;

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
        followPlayer();
    }


    void followPlayer()
    {
        RotateTowards(astroBuddy.transform.position);

        /*
        if ((this.transform.position - astroBuddy.transform.position).magnitude >= 1f)
        {
            this.transform.position = Vector3.LerpUnclamped(this.transform.position, astroBuddy.transform.position, 0.5f * Time.deltaTime);
        }

        if ((this.transform.position - astroBuddy.transform.position).magnitude < 1f)
        {
            this.transform.position = Vector3.LerpUnclamped(this.transform.position, astroBuddy.transform.position, 2f * Time.deltaTime);
        }
        */
        if (Mathf.Abs((astroBuddy.transform.position - this.transform.position).magnitude) > 1.5f)
        {
            this.GetComponent<Rigidbody2D>().velocity = (astroBuddy.transform.position - this.transform.position).normalized * 4f;
        }
        



         



    }

    private void RotateTowards(Vector2 target)
    {
        var offset = 90f;
        Vector2 direction = target - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.name.Contains("Wall") || collision.collider.name.Contains("Floor") || collision.collider.name.Contains("Platform"))
        {
            Debug.Log("sdopğkrfsdokfopdskfpsddsfdsfdssd");
            Destroy(this.gameObject);
            
        }
    }
}
