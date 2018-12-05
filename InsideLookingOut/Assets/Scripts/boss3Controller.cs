using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss3Controller : MonoBehaviour {

    public float moveSpeed;
    private float speedHolder;
    public bool movingRight;

    public float madTime = 5f;
    public float madSpeedMultiplier = 3f;


    public Transform defaultPoint;
    public Transform endPoint;
    public Transform currentTargetPoint;
    public Transform leftPoint;
    public Transform rightPoint;

    private Animator anim;

    private Rigidbody2D myRigidBody;
    private SpriteRenderer sprRender;

    public GameObject deathParticle;

    private PlayerController player;

    private LevelManager lvlManager;

    public int state = 0;

    public int health = 3;

    public bool isAttacking;

    public GameObject water;


    // Use this for initialization
    void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        lvlManager = FindObjectOfType<LevelManager>();
        player = FindObjectOfType<PlayerController>();
        sprRender = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        currentTargetPoint = endPoint;
        isAttacking = false;
        //player = lvlManager.player;
    }

    // Update is called once per frame
    void Update() {






        if (player == null)
        {
            player = FindObjectOfType<PlayerController>();
        }



        anim.SetInteger("state", state);



        switch (state)
                {

                case 0:
                //idle
                anim.Play("sharkIdle");
                break;

            case 1:
                //charging

                anim.Play("sharkRun");


                
                // Compute the next position -- straight flight
                Vector3 nextPos = Vector3.MoveTowards(transform.position, currentTargetPoint.transform.position, moveSpeed * Time.deltaTime);

                transform.position = nextPos;

                //Arrived at default point
                if (nextPos == defaultPoint.transform.position)
                {
                    moveToEnd();
                    transform.localScale = new Vector3(.5f, .5f, .5f);
                    state = 0 ;  
                }

                // reach the spikes; damage boss
                if (nextPos == endPoint.transform.position)
                {
                    moveToDefault();
                    
                }
                break;


            case 2:
                //going back to start
                break;


    }


            /*if (state != 0)
            {
                if (movingRight)
                {
                    myRigidBody.velocity = new Vector3(moveSpeed, myRigidBody.velocity.y, 0f);
                    transform.localScale = new Vector3(.27f, .27f, .27f);
                }
                else
                {
                    myRigidBody.velocity = new Vector3(-moveSpeed, myRigidBody.velocity.y, 0f);
                    transform.localScale = new Vector3(-.27f, .27f, .27f);
                }
            }
            */

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

    void moveToDefault()
    {
        currentTargetPoint = defaultPoint;
        transform.localScale = new Vector3(-.5f, .5f, .5f);
    }

    void moveToEnd()
    {
        currentTargetPoint = endPoint;
        transform.localScale = new Vector3(.5f, .5f, .5f);
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            moveToDefault();
            lvlManager.respawn();
        }


        if (other.gameObject.tag == "bossSpike")
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
