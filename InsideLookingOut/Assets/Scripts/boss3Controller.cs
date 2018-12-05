using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss3Controller : MonoBehaviour {

    public float moveSpeed;
    private float speedHolder;
    public bool movingRight;

    public float madTime = 5f;
    public float madSpeedMultiplier = 3f;

    public Transform leftPoint;
    public Transform rightPoint;

    private Animator anim;

    private Rigidbody2D myRigidBody;
    private SpriteRenderer sprRender;

    public GameObject deathParticle;

    private PlayerController player;

    private LevelManager lvlManager;

    private int state = 0;

    public int health = 3;


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

        if (state != 3)
        {
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
        }

 
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

    public IEnumerator getMad()
    {

        state = 3;
        speedHolder = moveSpeed;
        moveSpeed *= madSpeedMultiplier;
        sprRender.color = Color.red;

        yield return new WaitForSeconds(madTime);
        state = 1;
        moveSpeed = speedHolder;
        sprRender.color = Color.white;
        yield return null;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {

                lvlManager.respawn();


        }


        if (other.gameObject.tag == "cone")
        {
            health--;
            Instantiate(deathParticle, transform.position, transform.rotation);

            
            if(health == 0)
            {
                Destroy(gameObject);
            }
        }
    }


    public IEnumerator beamAttack()
    {
 

        yield return new WaitForSeconds(3f);


        yield return null;
    }


    public IEnumerator chargeAttack()
    {


        yield return new WaitForSeconds(3f);


        yield return null;
    }

    public IEnumerator laserAttack()
    {


        yield return new WaitForSeconds(3f);


        yield return null;
    }
}
