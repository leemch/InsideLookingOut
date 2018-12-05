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

    public bool isCasting;

    public GameObject water;


    // Use this for initialization
    void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        lvlManager = FindObjectOfType<LevelManager>();
        player = FindObjectOfType<PlayerController>();
        sprRender = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        currentTargetPoint = endPoint;
        isCasting = false;
        //player = lvlManager.player;

        state = 1;
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
                    state = 2;
                }

                // reach the spikes; damage boss
                if (nextPos == endPoint.transform.position)
                {
                    moveToDefault();
                    
                }
                break;


            case 2:
                if (!isCasting)
                {
                    StartCoroutine("castWaterAttack");
                }
                break;

            case 3:

                break;

            case 4:

                break;




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



    public IEnumerator castWaterAttack()
    {
        isCasting = true;
        anim.Play("sharkWave");

                water.GetComponent<Animator>().Play("waterAnim");

        yield return new WaitForSeconds(12f);


        state = 0;
        isCasting = false;

        yield return null;
    }


    public IEnumerator castBeamAttack()
    {
        isCasting = true;
        anim.Play("sharkWave");

    
        //water.GetComponent<Animator>().Play("waterAnim");

        yield return new WaitForSeconds(12f);


        state = 0;
        isCasting = false;

        yield return null;
    }


}
