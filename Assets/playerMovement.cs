using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class playerMovement : MonoBehaviour
{
    // bools to see if the character unlocked the levels
    public static bool unlockedOne = false, unlockedTwo = false, unlockedThree = false, unlockedFour = false, unlockedFive = false, unlockedSix = false;


    //able to move
    public bool ableToMove = true;

    // determine whether the player will be facing right or not
    [HideInInspector]
    public static bool facingRight = true;


    // preassigning the rigidbody and initialising the gameobject for later reference
    Rigidbody2D myRigidbody;
    public static GameObject thisPlayer;



    //smooth time ref for the movePlayer function
    private Vector3 smoothTime = Vector3.zero;


    //Movement speed related variables
    [HideInInspector]
    public static float horizontalMove;

    public float runSpeed;
    public float jumpForce;

    // bullet amount
    public static int fireballAmount = 500;

    



    //Movement restriction variables
    [HideInInspector]
    public static bool canJump = true;

    //current scene var
    int currentScene;


    //timers to reset level
    float timerResetStart;
    float timerResetEnd = 2f;












    void Start()
    {
        // initialising the rigidbody of this object and the gameobject ( to use later for scene swaps etc )
        myRigidbody = this.GetComponent<Rigidbody2D>();
        thisPlayer = this.gameObject;

        currentScene = SceneManager.GetActiveScene().buildIndex;


        // change color of the player at the start
        if (startScreenHolder.colorSelected)
        {
            this.GetComponent<SpriteRenderer>().color = startScreenHolder.selectedColor;
        }
        
        



    }

    // Update is called once per frame
    void Update()
    {
        
        


        // flip character
        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.eulerAngles = Vector3.zero;
        }

        resetLevel();


        // fix rotation of the player if it is bugged
        if (this.transform.rotation.z != 0)
        {
            this.transform.eulerAngles = new Vector3(this.transform.rotation.x, this.transform.rotation.y, 0f);
        }


        velocityLimiter(7f, 7f);
        // getting the input from the user to move left and right
        horizontalMove = (Input.GetAxisRaw("Horizontal") * runSpeed);



        if(canJump == false)
        {
            runSpeed = 10f;
        }
        else
        {
            runSpeed = 20f;
        }

    }

    private void FixedUpdate()
    {
        if (ableToMove == true)
        {
            movePlayer(horizontalMove * Time.deltaTime);

            playerJump(jumpForce);

            fixRotation();
        }


    }



    // function to move player
    void movePlayer(float horizMove)
    {

        Vector3 targetVelocity = new Vector2(horizMove * 10f, myRigidbody.velocity.y);

        myRigidbody.velocity = Vector3.SmoothDamp(myRigidbody.velocity, targetVelocity, ref smoothTime, 0.1f);


        if (horizMove > 0 && facingRight == false)
        {
            //flipCharachter();
        }
        if (horizMove < 0 && facingRight == true)
        {
            //flipCharachter();
        }
        if(horizMove == 0)
        {
            
        }



    }

    void velocityLimiter(float maxVeloX ,float maxVeloY)
    {
        // if bigger than 0 and max velo
        if(myRigidbody.velocity.x > maxVeloX && myRigidbody.velocity.x > 0)
        {
            myRigidbody.velocity = new Vector2(maxVeloX, myRigidbody.velocity.y);
        }

        if (myRigidbody.velocity.x < -maxVeloX && myRigidbody.velocity.x < 0)
        {
            myRigidbody.velocity = new Vector2(-maxVeloX, myRigidbody.velocity.y);
        }

        // iff bigger than 0 and max velo y

        if (myRigidbody.velocity.y > maxVeloY && myRigidbody.velocity.y > 0)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x , maxVeloY);
        }

        if (myRigidbody.velocity.y < -maxVeloY && myRigidbody.velocity.y < 0)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, -maxVeloY);
        }




    }



    // function that will flip the charachter 180 degrees
    void flipCharachter()
    {

        facingRight = !facingRight;

        transform.Rotate(0, 180, 0);

    }


    // function that will make the charachter jump
    void playerJump(float givenSpeed)
    {
        if (Input.GetKey(KeyCode.Space))
        {

            if (canJump == true)
            {
                myRigidbody.AddForce(new Vector2(0, givenSpeed));
                canJump = false;
            }

        }
        
    }

    void fixRotation()
    {

        if (Input.GetKeyDown("a") && facingRight == true)
        {
            facingRight = false;
            transform.Rotate(0, 180, 0);
        }
        if (Input.GetKeyDown("d") && facingRight == false)
        {
            facingRight = true;
            transform.Rotate(0, 180, 0);
        }
    }

    // reset level by holding the R key
    void resetLevel()
    {
        if (Input.GetKey("r"))
        {
            timerResetStart += Time.deltaTime;
        }

        if (Input.GetKeyUp("r"))
        {
            timerResetStart = 0f;
        }

        if(timerResetStart >= timerResetEnd)
        {
            SceneManager.LoadScene(currentScene);
        }
        

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag.Equals("spikeBall"))
        {
            SceneManager.LoadScene(currentScene);
        }

        if (collision.collider.tag.Equals("fireBall"))
        {
            SceneManager.LoadScene(currentScene);
        }

        if (collision.collider.tag.Equals("Ammo"))
        {
            fireballAmount += 1;
            Destroy(collision.collider.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if you get hit by a bullet , reload the current scene and start over
        if (collision.tag.Equals("bullet") || collision.tag.Equals("turret"))
        {
            SceneManager.LoadScene(currentScene);
        }

        // if the collision is a start checker , we will have unlocked that level
        if (collision.name.Equals("startCheckerOne"))
        {
            unlockedOne = true;         
        }
        if (collision.name.Equals("startCheckerTwo"))
        {
            unlockedTwo = true;
        }
        if (collision.name.Equals("startCheckerThree"))
        {
            unlockedThree = true;
        }
        if (collision.name.Equals("startCheckerFour"))
        {
            unlockedFour = true;
        }
        if (collision.name.Equals("startCheckerFive"))
        {
            unlockedFive = true;
        }
        if (collision.name.Equals("startCheckerSix"))
        {
            unlockedSix = true;
        }




        


    }

   


}
