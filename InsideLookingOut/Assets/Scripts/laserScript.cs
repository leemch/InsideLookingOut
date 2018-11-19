using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserScript : MonoBehaviour {

    public float velX = 5f;
    public float velY = 0f;
    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = new Vector2(velX, velY);
        Destroy(gameObject, 3f);
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);

    }
}
