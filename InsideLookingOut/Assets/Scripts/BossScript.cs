using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour {

    public bool bossActive;

    private float fireCount;

    public GameObject projectile;
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
            if(fireCount < 5)
            {
                if (Time.time > nextFire)
                {
                    nextFire = Time.time + fireRate;
                    fire();
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

}
