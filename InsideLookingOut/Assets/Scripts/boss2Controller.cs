using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss2Controller : MonoBehaviour {

    public float moveSpeed;
    public bool movingRight;

    public Transform leftPoint;
    public Transform rightPoint;

    private Rigidbody2D myRigidBody;

    public GameObject deathParticle;

    private PlayerController player;

    private LevelManager lvlManager;

    private int state = 0;

    // Use this for initialization
    void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        lvlManager = FindObjectOfType<LevelManager>();
        player = FindObjectOfType<PlayerController>();
        //player = lvlManager.player;
    }

    // Update is called once per frame
    void Update() {


        if(player == null)
        {
            player = FindObjectOfType<PlayerController>();
        }

        if(lvlManager.currentForm != transformation.trashCan)
        {
            if (player.transform.position.x > leftPoint.position.x && player.transform.position.x < rightPoint.position.x && lvlManager.isDead == false)
            {
                if (transform.position.x - player.transform.position.x > 0f)
                {
                    movingRight = false;
                }
                else
                {
                    movingRight = true;
                }
            }
        }


        switch (state)
        {
            case 0:
                    if (movingRight && transform.position.x >= rightPoint.position.x)
        {
            movingRight = false;

        }
        if (!movingRight && transform.position.x <= leftPoint.position.x)
        {
            movingRight = true;

        }


                break;


            case 1:

                if (!(transform.position.x >= rightPoint.position.x) && !(transform.position.x <= leftPoint.position.x)) {
                    if (transform.position.x - player.transform.position.x > 0f)
                    {
                        movingRight = false;
                    }
                    else
                    {
                        movingRight = true;
                    }
                }
                else
                {
                    state = 0;
                }

                break;
    }


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

    //private void OnTriggerEnter2D(Collider2D other)
    //{
        //if(other.tag == "KillPlane")
        //{
            //Destroy(gameObject);
        //}

    //}

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
            Destroy(gameObject);

        }
    }
}
