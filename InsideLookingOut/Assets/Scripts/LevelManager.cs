using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public float waitToRespawn;
    public PlayerController player;

    public GameObject deathParticle;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
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
}
