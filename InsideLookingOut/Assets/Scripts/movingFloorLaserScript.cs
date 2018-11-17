using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingFloorLaserScript : MonoBehaviour {

    public GameObject laserUp;
    public GameObject laserDown;
    Vector2 bulletPos;
    public float fireRate = 0.5f;
    float nextFire = 0.0f;
    public bool shootDown;


	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {


            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                fire();
            }
        
	}


    void fire()
    {
        bulletPos = transform.position;

        if(!shootDown)
        Instantiate(laserUp, bulletPos, Quaternion.identity);
        else
        Instantiate(laserDown, bulletPos, Quaternion.identity);
    }
}
