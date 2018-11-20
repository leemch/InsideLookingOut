using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level2Start : MonoBehaviour {
    private LevelManager lvlManager;
    // Use this for initialization
    void Start () {
        lvlManager = FindObjectOfType<LevelManager>();

        lvlManager.unlockTransform("trash can");
        lvlManager.unlockTransform("mouse");

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
