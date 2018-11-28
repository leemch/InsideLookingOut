using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingConeScript : MonoBehaviour {

    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            rb.bodyType = RigidbodyType2D.Dynamic ;
            //Destroy(gameObject);
        }
    }

}
