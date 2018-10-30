using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooterBotController : MonoBehaviour {

    public float moveSpeed;
    public bool movingRight;

    public Transform leftPoint;
    public Transform rightPoint;

    private Rigidbody2D myRigidBody;


    private PlayerController player;

    private LevelManager lvlManager;

    public spotLightScript spotLight;   

    private int state = 0;

    public GameObject bullet;
    Vector2 bulletPos;
    public float fireRate = 1f;
    float nextFire = 0.0f;

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
    }


        if (movingRight)
        {
            myRigidBody.velocity = new Vector3(moveSpeed, myRigidBody.velocity.y, 0f);
            transform.localScale = new Vector3(0.19f, 0.19f, 0.19f);    
        }
        else
        {
            myRigidBody.velocity = new Vector3(-moveSpeed, myRigidBody.velocity.y, 0f);
            transform.localScale = new Vector3(-0.19f, 0.19f, 0.19f);
        }

        if (spotLight.playerSpotted && lvlManager.isDead == false && lvlManager.currentForm != transformation.trashCan)
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                fire();
            }
        }
        else
        {
            spotLight.playerSpotted = false;
        }


    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
        //if(other.tag == "KillPlane")
        //{
            //Destroy(gameObject);
        //}

    //}



    void fire()
    {
        bulletPos = transform.position;
        Instantiate(bullet, bulletPos, Quaternion.identity);

    }


}
