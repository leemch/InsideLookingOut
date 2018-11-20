using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level3Start : MonoBehaviour {
    private LevelManager lvlManager;
    // Use this for initialization
    void Start () {
        lvlManager = FindObjectOfType<LevelManager>();

        lvlManager.unlockTransform("trash can");
        lvlManager.unlockTransform("mouse");
        lvlManager.unlockTransform("penguin");

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
