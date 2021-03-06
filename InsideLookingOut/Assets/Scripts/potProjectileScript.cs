﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potProjectileScript : MonoBehaviour {

    public float moveSpeed = 3f;

    Rigidbody2D rb;
    //PlayerController player;

    public float arcHeight = 3;
    public GameObject endPos;

    Vector2 startPos;
    Vector2 targetPos;
    Vector2 moveDirection;

	// Use this for initialization
	void Start () {

        //player = FindObjectOfType<PlayerController>();

        startPos = transform.position;
        targetPos = endPos.transform.position;

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
        //if (nextPos == targetPos) Arrived();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("ground"))
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //if (other.collider.gameObject.layer == LayerMask.NameToLayer("ground"))
        //{
            //Destroy(gameObject);
        //}
    }




}
