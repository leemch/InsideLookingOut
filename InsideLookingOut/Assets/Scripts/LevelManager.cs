﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum transformation { robot, trashCan, mouse, penguin };

public class LevelManager : MonoBehaviour {

    public float waitToRespawn;
    public PlayerController player;

    bool[] transformUnlocks = new bool[] { false, false, false, false };

    public bool isDead;

    public GameObject deathParticle;

    public int coins;
    public int battery;

    public bool hasCigs;
    public bool hasKey;

    public bool inDialog;

    public Text pointText;
    public Text batteryText;

    public int startingLives;
    public int currentLives;
    public Text livesText;

    public Vector3 respawnPoint;

    public GameObject trashcanIcon;
    public GameObject mouseIcon;

    public GameObject mousePlayer;
    public GameObject trashCanPlayer;
    public GameObject basePlayer;
    public GameObject penguinPlayer;

    public GameObject transformParticle;

    CameraController cam;




    public transformation currentForm;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerController>();
        cam = FindObjectOfType<CameraController>();

        pointText.text = "Points: " + coins;
        battery = 100;
        batteryText.text = "Battery: " + battery + "%";

        respawnPoint = player.transform.position;

        currentLives = startingLives;
        livesText.text = "Lives x " + currentLives;

        currentForm = transformation.robot;

        isDead = false;

        hasCigs = false;
        hasKey = false;
        inDialog = false;

    }
	
	// Update is called once per frame
	void Update () {

        if (!inDialog)
        {

            if (Input.GetKeyDown("1"))
            {

                transformPlayer("base");
            }

            if (Input.GetKeyDown("2"))
            {
                if (battery > 0)
                {
                    if (transformUnlocks[0] == true)
                        transformPlayer("trash can");
                }

            }
            if (Input.GetKeyDown("3"))
            {
                if (transformUnlocks[1] == true)
                    transformPlayer("mouse");
            }
            //if (Input.GetKeyDown("4"))
            //{
            //    transformPlayer("penguin");
            //}
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
        isDead = true;

        Instantiate(deathParticle, player.transform.position, player.transform.rotation);

        yield return new WaitForSeconds(waitToRespawn);

        player.transform.parent = null;
        player.transform.position = respawnPoint;
        player.gameObject.SetActive(true);
        transformPlayer("base");
        isDead = false;

        yield return null;
    }

    public void addCoins(int amount)
    {
        coins += amount;
        pointText.text = "Points: " + coins;
    }

    public void addLives(int amount)
    {
        currentLives += amount;
        livesText.text = "Lives x" + currentLives;
    }

    public void addBattery(int amount)
    {
        battery += amount;

        if (battery > 100)
            battery = 100;
        if (battery < 0)
            battery = 0;

        batteryText.text = "Battery: " + battery + "%";
    }

    public void setBattery(int amount)
    {
        battery = amount;

        batteryText.text = "Battery: " + battery + "%";
    }

    public void unlockTransform(string type)
    {
        switch (type)
        {
            case "trash can":
                transformUnlocks[0] = true;
                trashcanIcon.SetActive(true);
                break;

            case "mouse":
                transformUnlocks[1] = true;
                mouseIcon.SetActive(true);
                break;

            case "penguin":
                transformUnlocks[2] = true;
                break;

        }
    }

    public void resetPlayer()
    {
        setBattery(100);
    }



    public void transformPlayer(string type)
    {

        if (!isDead)
        {
            if (currentForm != transformation.robot)
            {
                Destroy(FindObjectOfType<transformTimerScript>().timerText.gameObject);
            }

            bool facingRight;
            if(player.transform.localScale.x > 0)
            {
                facingRight = true;
            }
            else
            {
                facingRight = false;
            }

            Instantiate(transformParticle, player.gameObject.transform.position, player.gameObject.transform.rotation);
            switch (type)
            {
                case "base":
                    Instantiate(basePlayer, player.gameObject.transform.position, player.gameObject.transform.rotation);
                    currentForm = transformation.robot;
                    break;

                case "trash can":
                    Instantiate(trashCanPlayer, player.gameObject.transform.position, player.gameObject.transform.rotation);
                    currentForm = transformation.trashCan;
                    addBattery(-5);
                    break;

                case "mouse":
                    Instantiate(mousePlayer, player.gameObject.transform.position, player.gameObject.transform.rotation);
                    //addBattery(-10);
                    currentForm = transformation.mouse;
                    break;

                case "penguin":
                    Instantiate(penguinPlayer, player.gameObject.transform.position, player.gameObject.transform.rotation);
                    //addBattery(-10);
                    currentForm = transformation.penguin;
                    break;
            }

            Destroy(player.gameObject);

            player = FindObjectOfType<PlayerController>();
            cam.target = player.gameObject;

            if (!facingRight)
            {
                player.transform.localScale = new Vector3(-player.transform.localScale.x, player.transform.localScale.y, player.transform.localScale.z);
            }


        }

    }


}
