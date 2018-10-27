using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batteryScript : MonoBehaviour {

    private LevelManager lvlManager;
    public int chargeAmount = 10;

    // Use this for initialization
    void Start()
    {
        lvlManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            lvlManager.addBattery(chargeAmount);
            Destroy(gameObject);
        }

    }
}
