using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cageScript : MonoBehaviour {

    Animator cageAnimator;

	// Use this for initialization
	void Start () {
        cageAnimator = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            cageAnimator.SetBool("opened", true);
        }

    }
}
