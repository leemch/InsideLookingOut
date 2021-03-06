﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatformReset : MonoBehaviour {

    public platformPathScript platform;
    LevelManager lvlManager;

    // Use this for initialization
    void Start () {
        lvlManager = FindObjectOfType<LevelManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            platform.reset();
            lvlManager.player.transform.position = lvlManager.respawnPoint;
        }
    }
}
