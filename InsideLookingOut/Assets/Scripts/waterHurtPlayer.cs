using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterHurtPlayer : MonoBehaviour {

    private LevelManager lvlManager;

    public bool killedPlayer;

	// Use this for initialization
	void Start () {
        lvlManager = FindObjectOfType<LevelManager>();
        killedPlayer = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (!killedPlayer)
            {
                if (lvlManager.currentForm != transformation.trashCan)
                {
                    lvlManager.respawn();
                    killedPlayer = true;
                }

            }
        }
    }


}
