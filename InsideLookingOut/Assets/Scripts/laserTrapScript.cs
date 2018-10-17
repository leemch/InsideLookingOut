using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserTrapScript : MonoBehaviour {

    public GameObject laser;
    Vector2 bulletPos;
    public float fireRate = 0.5f;
    float nextFire = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            fire();
        }
	}


    void fire()
    {
        bulletPos = transform.position;
        Instantiate(laser, bulletPos, Quaternion.identity);
    }
}
