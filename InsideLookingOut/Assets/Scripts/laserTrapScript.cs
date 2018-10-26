using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserTrapScript : MonoBehaviour {

    public GameObject laser;
    public GameObject laserLeft;
    Vector2 bulletPos;
    public float fireRate = 0.5f;
    float nextFire = 0.0f;

    public floorTrigger trigger;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (trigger.triggered)
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                fire();
            }
        }
	}


    void fire()
    {
        bulletPos = transform.position;
        Instantiate(laser, bulletPos, Quaternion.identity);
        Instantiate(laserLeft, bulletPos, Quaternion.identity);
    }
}
