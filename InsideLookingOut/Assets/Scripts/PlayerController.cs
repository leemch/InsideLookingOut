using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public float moveSpeed;
    private Rigidbody2D myRigidbody;
    public GameObject transformParticle;
    public float jumpSpeed;



    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    public bool isGrounded;

    private Animator myAnim;

    public Vector3 respawnPoint;
    public LevelManager lvlManager;

    public bool canTransform;
    public bool isTransformed;

    private SpriteRenderer sprRender;
    public Sprite trashcanSprite;
    private Sprite playerSprite;

    



    // Use this for initialization
    void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        respawnPoint = transform.position;
        lvlManager = FindObjectOfType<LevelManager>();
        isTransformed = false;

        sprRender = GetComponent<SpriteRenderer>();


    }
	
	// Update is called once per frame
	void Update () {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            myRigidbody.velocity = new Vector3(moveSpeed, myRigidbody.velocity.y, 0f);
            transform.localScale = new Vector3(.5f, .5f, .5f);

        }else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            myRigidbody.velocity = new Vector3(-moveSpeed, myRigidbody.velocity.y, 0f);
            transform.localScale = new Vector3(-.5f, .5f, .5f);
        }
        else
        {
            myRigidbody.velocity = new Vector3(0f, myRigidbody.velocity.y, 0f);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpSpeed, 0f);
        }

        myAnim.SetFloat("Speed", Mathf.Abs(myRigidbody.velocity.x));
        myAnim.SetBool("Grounded", isGrounded);

        if (Input.GetKeyDown("t"))
        {

            print("space key was pressed");

            if (canTransform)
            {
                if (isTransformed)
                {
                    isTransformed = false;
                    myAnim.Play("Player Idle");
                    moveSpeed = 3;
                }
                else
                {
                    Instantiate(transformParticle, transform.position, transform.rotation);
                    isTransformed = true;
                    moveSpeed = 0;
                    myAnim.Play("trashCan");

                }
            }
        }


        if (Input.GetKeyDown("1"))
        {

                if (isTransformed)
                {
                //gameObject.SetActive(true);
                    isTransformed = false;

                }
                else
                {               
                Instantiate(transformParticle, transform.position, transform.rotation);
                gameObject.SetActive(false);
                //mousePlayer.SetActive(true);
                isTransformed = true;
                }      
        }



    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "KillPlane")
        {
            //transform.position = respawnPoint;
            
            lvlManager.respawn();

        }

        if(other.tag == "checkPoint")
        {
            respawnPoint = other.transform.position;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "movingPlatform")
        {
            transform.parent = other.transform;
        }    
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "movingPlatform")
        {
            transform.parent = null;
        }
    }

}
