using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour {

    public bool bossActive;

    private float fireCount;

    public GameObject projectile;
    public GameObject potObject;

    public int potsToShoot = 3;
    private int potCount = 0;

    private Animator anim;


    Vector2 bulletPos;
    public float fireRate = 2f;
    float nextFire = 0.0f;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();

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
                        anim.Play("frogVomit");
                        fire();
                        anim.Play("frogVomit");
                        fireCount++;
                    }
                    else if(potCount < potsToShoot)
                    {
                        nextFire = Time.time + fireRate;
                        //anim.Play("frogVomit");
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

        potObject.GetComponent<Animator>().SetBool("triggered", true);
    }

}
