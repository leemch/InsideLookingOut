using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public float waitToRespawn;
    PlayerController player;

    public GameObject deathParticle;

    public int coins;
    public int health;

    public Text pointText;
    public Text healthText;

    public int startingLives;
    public int currentLives;
    public Text livesText;

    public GameObject mousePlayer;
    public GameObject basePlayer;

    public GameObject currentPlayer;

    public GameObject transformParticle;

    CameraController cam;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerController>();
        cam = FindObjectOfType<CameraController>();

        pointText.text = "Points: " + coins;
        health = 100;
        healthText.text = "Health: " + health;

        currentLives = startingLives;
        livesText.text = "Lives x " + currentLives;

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("1"))
        {
            Instantiate(transformParticle, transform.position, transform.rotation);   
            //mousePlayer.SetActive(true);
            mousePlayer.transform.position = basePlayer.transform.position;
            mousePlayer.SetActive(true);
            cam.target = mousePlayer;
            player.gameObject.SetActive(false);
        }

    }

    public void respawn()
    {
        currentLives -= 1;
        livesText.text = "Lives x" + currentLives;

        if (currentLives > 0)
        {
            StartCoroutine("RespawnCo");
        }
        else
        {
            player.gameObject.SetActive(false);
        }
    }


    public IEnumerator RespawnCo()
    {
        player.gameObject.SetActive(false);

        Instantiate(deathParticle, player.transform.position, player.transform.rotation);

        yield return new WaitForSeconds(waitToRespawn);

        player.transform.parent = null;
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
