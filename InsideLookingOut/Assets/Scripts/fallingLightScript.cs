using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingLightScript : MonoBehaviour {

    private Animator anim;
    private BossScript boss;

	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();
        boss = FindObjectOfType<BossScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            anim.SetBool("cut", true);
            if (boss.bossActive)
            {
                boss.die();
            }
        }

    }

}
