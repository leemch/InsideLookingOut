using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spotLightScript : MonoBehaviour {

    public bool playerSpotted;

	// Use this for initialization
	void Start () {
        playerSpotted = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag == "Player")
        {
            playerSpotted = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerSpotted = false;
        }
    }
}
