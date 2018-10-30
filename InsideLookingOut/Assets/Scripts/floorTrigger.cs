using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorTrigger : MonoBehaviour {
    private LevelManager lvlManager;
    public bool triggered;

	// Use this for initialization
	void Start () {
        triggered = false;
        lvlManager = FindObjectOfType<LevelManager>();
    }
	
	// Update is called once per frame
	void Update () {
            if (lvlManager.isDead == true)
            {
                triggered = false;
            }
        }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {

                if (lvlManager.currentForm != transformation.trashCan && lvlManager.isDead == false)
                    triggered = true;        
                else
                    triggered = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            triggered = false;
        }
    }
}
