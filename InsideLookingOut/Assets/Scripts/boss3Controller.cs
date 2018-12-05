using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public GameObject beam;

    public int attackStage = 1;

    public AudioSource hurtSound;
    public AudioSource waterRiseSound;
    public AudioSource beamSound;


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

        state = 0;
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
                if (!isCasting)
                {
                    StartCoroutine("idleWait");
                }
                    
                
                break;

            case 1:
                //charging

                if (!isCasting)
                {
                    anim.Play("sharkRun");

                    // Compute the next position -- straight flight
                    Vector3 nextPos = Vector3.MoveTowards(transform.position, currentTargetPoint.transform.position, moveSpeed * Time.deltaTime);

                    transform.position = nextPos;

                    //Arrived at default point
                    if (nextPos == defaultPoint.transform.position)
                    {
                        moveToEnd();
                        transform.localScale = new Vector3(.5f, .5f, .5f);
                        attackStage++;
                        state = 0;

                    }

                    // reach the spikes; damage boss
                    if (nextPos == endPoint.transform.position)
                    {
                        StartCoroutine("hurtBoss");
                    }
                }
                break;


            case 2:
                if (!isCasting)
                {
                    StartCoroutine("castWaterAttack");
                }
                break;

            case 3:
                if (!isCasting)
                {
                    StartCoroutine("castBeamAttack");
                }
                break;

            case 4:

                break;




        }

    }


    public IEnumerator castWaterAttack()
    {
        waterRiseSound.Play();
        isCasting = true;
        anim.Play("sharkWave");

        water.GetComponent<Animator>().Play("waterAnim");

        yield return new WaitForSeconds(12f);

        water.GetComponent<waterHurtPlayer>().killedPlayer = false;
        state = 0;
        isCasting = false;
        attackStage++;
        waterRiseSound.Stop();

        yield return null;
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
            

            if (lvlManager.currentForm != transformation.trashCan)
            {
                lvlManager.respawn();
                moveToDefault();
            }
                

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



    public IEnumerator hurtBoss()
    {
        hurtSound.Play();
        isCasting = true;
        sprRender.color = Color.red;
        health--;
        if (health == 0)
        {
            SceneManager.LoadScene("endOfDemo");
            //Destroy(gameObject);
        }

        yield return new WaitForSeconds(3f);

        sprRender.color = Color.white;
        moveToDefault();
        isCasting = false;

        yield return null;
    }


    public IEnumerator castBeamAttack()
    {
        beamSound.Play();
        isCasting = true;
        anim.Play("sharkWave");

    
        beam.GetComponent<Animator>().Play("beamAnim");

        yield return new WaitForSeconds(8f);


        state = 0;
        isCasting = false;
        attackStage++;

        yield return null;
    }


    public IEnumerator idleWait()
    {
        isCasting = true;



        yield return new WaitForSeconds(3f);
        
        if (attackStage > 3)
        {
            attackStage = 1;
        }  

            


        state = attackStage;
        isCasting = false;

        yield return null;
    }


}
