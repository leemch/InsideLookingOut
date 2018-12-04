using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurtPlayerCollision : MonoBehaviour {

    private LevelManager lvlManager;

	// Use this for initialization
	void Start () {
        lvlManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(lvlManager.currentForm != transformation.trashCan)
            lvlManager.respawn();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (lvlManager.currentForm != transformation.trashCan)
                lvlManager.respawn();
        }
    }
}
