using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss1trigger : MonoBehaviour {

    BossScript boss;

	// Use this for initialization
	void Start () {
        boss = FindObjectOfType<BossScript>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        boss.bossActive = true;

    }
}
