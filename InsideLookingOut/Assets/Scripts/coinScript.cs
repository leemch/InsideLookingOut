using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScript : MonoBehaviour {

    private LevelManager lvlManager;

	// Use this for initialization
	void Start () {
        lvlManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            lvlManager.addCoins(1);
            Destroy(gameObject);
        }
        
    }
}
