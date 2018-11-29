﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour {

    public bool bossActive;

    private float fireCount;

    public GameObject projectile;
    public GameObject potObject;

    public int potsToShoot = 3;
    private int potCount = 0;



    Vector2 bulletPos;
    public float fireRate = 2f;
    float nextFire = 0.0f;

    // Use this for initialization
    void Start () {
        bossActive = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (bossActive)
        {
                if (Time.time > nextFire)
                {
                    if (fireCount < 5)
                    {
                        nextFire = Time.time + fireRate;
                        fire();
                        fireCount++;
                    }
                    else if(potCount < potsToShoot)
                    {
                        nextFire = Time.time + fireRate;
                        firePot();
                        fireCount++;

                    }

                }          
        }

	}


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            bossActive = true;
        }
    }


    void fire()
    {
        Instantiate(projectile, transform.position, Quaternion.identity);
    }

    void firePot()
    {
        Instantiate(potObject, transform.position, Quaternion.identity);
    }

}
