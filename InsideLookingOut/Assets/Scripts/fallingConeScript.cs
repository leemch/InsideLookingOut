using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingConeScript : MonoBehaviour {

    private Rigidbody2D rb;
    public GameObject startingPoint;

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
            rb.freezeRotation = true;
            rb.mass = 5;
            //Destroy(gameObject);
        }

        if (other.gameObject.tag == "Boss" || other.gameObject.layer == LayerMask.NameToLayer("ground"))
        {
            //Destroy(gameObject);
            reset();
        }
    }


    void reset()
    {
        rb.bodyType = RigidbodyType2D.Static;
        transform.position = startingPoint.transform.position;
    }

}
