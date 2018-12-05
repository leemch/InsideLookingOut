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



                state = 1;


 
                switch (state)
                {
                case 0:

                myRigidBody.velocity = new Vector3(0f, myRigidBody.velocity.y, 0f);

                break;

            case 1:


                /*if (transform.position.x - player.transform.position.x > 0.5f)
                {
                    movingRight = false;
                }
                else
                {
                    movingRight = true;
                }
                */
                anim.SetInteger("state", 1);
                patrol();
                break;


            case 2:

                patrol();

                break;

            case 3:

                
                patrol();



                break;
    }


            if (state != 0)
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
