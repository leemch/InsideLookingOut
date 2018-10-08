using System.Collections;
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

    // Use this for initialization
    void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();
        lvlManager = FindObjectOfType<LevelManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (movingRight && transform.position.x >= rightPoint.position.x)
        {
            movingRight = false;
        }
        if(!movingRight && transform.position.x <= leftPoint.position.x)
        {
            movingRight = true;
        }

        if (movingRight)
        {
            myRigidBody.velocity = new Vector3(moveSpeed, myRigidBody.velocity.y, 0f);
        }
        else
        {
            myRigidBody.velocity = new Vector3(-moveSpeed, myRigidBody.velocity.y, 0f);
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
