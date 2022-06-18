using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxSpawner : MonoBehaviour
{
    public GameObject boxSpawnWall;

    public GameObject spawnedBox;

    int boxNumberChecker;
    public int boxLimit;

    bool isInRange;

    Vector3 startRotation;

    float boxCooldownStart;
    public float boxCooldownEnd = 3f;

    void Start()
    {
        startRotation = this.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        boxCooldownStart += Time.deltaTime;
        if (Input.GetKeyDown("e") && isInRange)
        {
            // swap levers rotation
            if (startRotation.z == 180 || startRotation.z == 0)
            {
                this.gameObject.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x + 180f, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
            }
            if (startRotation.z == 270)
            {
                this.gameObject.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y + 180f, this.transform.eulerAngles.z);
            }

            if (boxLimit > boxNumberChecker && boxCooldownStart >= boxCooldownEnd)
            {

                GameObject madeBox = Instantiate(spawnedBox, boxSpawnWall.transform.GetChild(0).transform.position, boxSpawnWall.transform.GetChild(0).transform.rotation);
                madeBox.GetComponent<Rigidbody2D>().mass = 1.8f;
                boxNumberChecker += 1;
                boxCooldownStart = 0f;

            }

            


        }



    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            isInRange = false;
        }
    }
}
