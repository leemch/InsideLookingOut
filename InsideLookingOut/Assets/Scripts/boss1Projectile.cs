using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss1Projectile : MonoBehaviour {

    private LevelManager lvlManager;

    public float moveSpeed = 3f;

    Rigidbody2D rb;
    PlayerController player;

    public float arcHeight = 5f;

    Vector2 startPos;
    Vector2 targetPos;
    Vector2 moveDirection;



	// Use this for initialization
	void Start () {
        lvlManager = FindObjectOfType<LevelManager>();
        player = FindObjectOfType<PlayerController>();

        startPos = transform.position;
        targetPos = player.transform.position;

        Destroy(gameObject, 5f);
    }
	
	// Update is called once per frame
	void Update () {
        //rb.velocity = new Vector2(velX, velY);
        //Destroy(gameObject, 3f);



        float x0 = startPos.x;
        float x1 = targetPos.x;
        float dist = x1 - x0;
        float nextX = Mathf.MoveTowards(transform.position.x, x1, moveSpeed * Time.deltaTime);
        float baseY = Mathf.Lerp(startPos.y, targetPos.y, (nextX - x0) / dist);
        float arc = arcHeight * (nextX - x0) * (nextX - x1) / (-0.25f * dist * dist);
        Vector2 nextPos = new Vector2(nextX, baseY + arc);

        // Rotate to face the next position, and then move there
        //transform.rotation = LookAt2D(nextPos - transform.position);
        transform.position = nextPos;

        // Do something when we reach the target
        if (nextPos == targetPos)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("ground"))
        //Destroy(gameObject);

        if (collision.tag == "Player")
        {
            Destroy(gameObject);
        }

    }






}
