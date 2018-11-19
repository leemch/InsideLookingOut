using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformScrit : MonoBehaviour {

    bool playerTouched;

	// Use this for initialization
	void Start () {
        playerTouched = false;

    }
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!playerTouched)
            {
                playerTouched = true;
                this.transform.parent.GetComponent<platformPathScript>().active = playerTouched;
            }
        }
    }
}
