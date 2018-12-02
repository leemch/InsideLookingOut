using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss2Controller : MonoBehaviour {

    public float moveSpeed;
    public bool movingRight;

    public Transform leftPoint;
    public Transform rightPoint;

    private Animator anim;

    private Rigidbody2D myRigidBody;
    private SpriteRenderer sprRender;

    public GameObject deathParticle;

    private PlayerController player;

    private LevelManager lvlManager;

    private int state = 0;

    // Use this for initialization
    void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        lvlManager = FindObjectOfType<LevelManager>();
        player = FindObjectOfType<PlayerController>();
        sprRender = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        //player = lvlManager.player;
    }

    // Update is called once per frame
    void Update() {


        if(player == null)
        {
            player = FindObjectOfType<PlayerController>();
        }

        if (lvlManager.currentForm != transformation.trashCan)
        {
            if (player.transform.position.x > leftPoint.position.x && player.transform.position.x < rightPoint.position.x && lvlManager.isDead == false)
            {
                if (Mathf.Abs(transform.position.x - player.transform.position.x) > 0.5f)
                {
                    state = 0;
                }
                else
                {
                    state = 1;
                }
            }
        }
        else
        {
            state = 2;
        }

        //anim.SetInteger("state", state);
                switch (state)
                {
                case 0:

                            if (transform.position.x - player.transform.position.x > 0.5f)
                            {
                                movingRight = false;
                            }
                            else
                            {
                                movingRight = true;
                            }
                break;

            case 1:
                myRigidBody.velocity = new Vector3(0f, myRigidBody.velocity.y, 0f);


                break;


            case 2:

                patrol();

                break;

            case 3:
                myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, 3f, 0f);
                patrol();


                break;
    }


            if (state != 1)
            {
                if (movingRight)
                {
                    myRigidBody.velocity = new Vector3(moveSpeed, myRigidBody.velocity.y, 0f);
                    transform.localScale = new Vector3(.25f, .25f, .25f);
                }
                else
                {
                    myRigidBody.velocity = new Vector3(-moveSpeed, myRigidBody.velocity.y, 0f);
                    transform.localScale = new Vector3(-.25f, .25f, .25f);
                }
            }


    }

    void patrol()
    {
        if (movingRight && transform.position.x >= rightPoint.position.x)
        {
            movingRight = false;

        }
        if (!movingRight && transform.position.x <= leftPoint.position.x)
        {
            movingRight = true;

        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (player.isTransformed)
            {
                Instantiate(deathParticle, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            else
            {
                lvlManager.respawn();
            }

        }


        if (other.gameObject.tag == "cone")
        {
            Instantiate(deathParticle, transform.position, transform.rotation);
            //state = 3;
            //Destroy(gameObject);
            sprRender.color = Color.red;

        }
    }
}
