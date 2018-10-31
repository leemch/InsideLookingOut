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

    private Transform[] children = null;





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

        if (lvlManager.inDialog == false)
        {


            if (Input.GetAxisRaw("Horizontal") > 0f)
            {

                myRigidbody.velocity = new Vector3(moveSpeed, myRigidbody.velocity.y, 0f);
                //transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
                if (transform.localScale.x < 0)
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

            }
            else if (Input.GetAxisRaw("Horizontal") < 0f)
            {

                myRigidbody.velocity = new Vector3(-moveSpeed, myRigidbody.velocity.y, 0f);
                if (transform.localScale.x > 0)
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                else
                    transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);

            }
            else
            {
                myRigidbody.velocity = new Vector3(0f, myRigidbody.velocity.y, 0f);
            }


            if (lvlManager.currentForm == transformation.penguin)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpSpeed, 0f);
                }

            }
            else
            {
                if (Input.GetButtonDown("Jump") && isGrounded)
                {
                    myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpSpeed, 0f);
                }
            }



            myAnim.SetFloat("Speed", Mathf.Abs(myRigidbody.velocity.x));
            myAnim.SetBool("Grounded", isGrounded);

        }


        else
        {
            myRigidbody.velocity = new Vector3(0, myRigidbody.velocity.y, 0f);
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
            lvlManager.respawnPoint = other.transform.position;
        }

        if (other.tag == "killGround")
        {
            lvlManager.respawn();
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
