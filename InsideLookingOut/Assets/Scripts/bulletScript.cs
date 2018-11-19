using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour {

    public float moveSpeed = 5f;

    Rigidbody2D rb;
    PlayerController player;

    Vector2 moveDirection;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        moveDirection = (player.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);
    }
	
	// Update is called once per frame
	void Update () {
        //rb.velocity = new Vector2(velX, velY);
        //Destroy(gameObject, 3f);

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
            Destroy(gameObject);
        //}
    }




}
