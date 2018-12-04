using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingLightScript : MonoBehaviour {

    private Animator anim;

    private BossScript boss;
	// Use this for initialization
	void Start () {
        boss = FindObjectOfType<BossScript>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            anim.SetBool("cut", true);
            Destroy(boss);
        }

        //if (other.tag == "Boss")
        //{
        //    Debug.Log("kill boss");
        //    Destroy(other.gameObject);
        //}

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Boss")
        {
            Debug.Log("kill boss");
            Destroy(other.gameObject);
        }
    }
}
