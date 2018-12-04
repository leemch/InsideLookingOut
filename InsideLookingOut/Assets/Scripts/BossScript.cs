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

    private LevelManager lvlManager;

    Vector2 bulletPos;
    public float fireRate = 2f;
    float nextFire = 0.0f;

    // Use this for initialization
    void Start () {
        lvlManager = FindObjectOfType<LevelManager>();
        anim = GetComponent<Animator>();

        bossActive = false;
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

    /*public void OnDestroy()
    {
        
    }
    */


    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //   if(other.tag == "Player")
     //   {
     //       bossActive = true;
     //   }

     //   if (other.tag == "killBoss")
     //   {
     //       Debug.Log("kill boss");
     //       Destroy(gameObject);
     //   }
    //}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "killBoss")
        {
            //die();
            //gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Player")
        {
            if (bossActive)
            {
                lvlManager.respawn();
            }
        }
    }


    public void die()
    {
        Debug.Log("kill boss");
        bossActive = false;
        anim.Play("frogDie");
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
