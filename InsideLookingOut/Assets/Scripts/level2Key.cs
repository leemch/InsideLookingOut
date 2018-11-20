using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level2Key : MonoBehaviour {

    private LevelManager lvlManager;
    public Animator floorAnimator;

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
            lvlManager.hasLevel2Key = true;
            floorAnimator.SetBool("hasKey", true);
            Destroy(gameObject);
        }
        
    }
}
