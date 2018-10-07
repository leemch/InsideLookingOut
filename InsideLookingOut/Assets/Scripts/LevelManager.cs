using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public float waitToRespawn;
    public PlayerController player;

    public GameObject deathParticle;

    public int coins;
    public int health;

    public Text pointText;
    public Text healthText;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();

        pointText.text = "Points: " + coins;
        health = 100;
        healthText.text = "Health: " + health;

    }
	
	// Update is called once per frame
	void Update () {



    }

    public void respawn()
    {
        StartCoroutine("RespawnCo");
    }


    public IEnumerator RespawnCo()
    {
        player.gameObject.SetActive(false);

        Instantiate(deathParticle, player.transform.position, player.transform.rotation);

        yield return new WaitForSeconds(waitToRespawn);

        player.transform.position = player.respawnPoint;
        player.gameObject.SetActive(true);

        yield return null;
    }

    public void addCoins(int amount)
    {
        coins += amount;
        pointText.text = "Points: " + coins;
    }
}
