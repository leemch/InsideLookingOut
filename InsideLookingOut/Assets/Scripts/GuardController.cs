﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardController : MonoBehaviour {

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
        player = FindObjectOfType<PlayerController>();
        lvlManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update() {

        if(Vector3.Distance(player.transform.position, transform.position) < 3f)
        {
            moveSpeed = 2f;
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
            moveSpeed = 1f;
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
            transform.localScale = new Vector3(0.29173f, 0.29173f, 0.29173f);
        }
        else
        {
            myRigidBody.velocity = new Vector3(-moveSpeed, myRigidBody.velocity.y, 0f);
            transform.localScale = new Vector3(-0.29173f, 0.29173f, 0.29173f);
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "KillPlane")
        {
            Destroy(gameObject);
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
    }
}