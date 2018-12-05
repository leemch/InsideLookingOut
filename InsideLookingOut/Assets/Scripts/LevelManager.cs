using System.Collections;
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

    public AudioSource coinSound;
    public AudioSource BatterySound;
    public AudioSource foundTransformSound;
    public AudioSource jumpSound;
    public AudioSource penguinFlapSound;
    public AudioSource talkSound;

    public int coins;
    private int coinBonusLifeCount;
    public int battery;

    public bool hasCigs;
    public bool hasKey;
    public bool hasSandwich;
    public bool hasLevel2Key;

    public bool inDialog;

    public Text pointText;
    public Text batteryText;

    public int startingLives;
    public int currentLives;
    public Text livesText;

    public Vector3 respawnPoint;

    public GameObject trashcanIcon;
    public GameObject mouseIcon;
    public GameObject penguinIcon;

    public GameObject mousePlayer;
    public GameObject trashCanPlayer;
    public GameObject basePlayer;
    public GameObject penguinPlayer;

    public GameObject gameOverScreen;


    public GameObject transformParticle;

    CameraController cam;

    public transformation currentForm;
    public string currentFormString;

    public bool isPaused;
    public bool boss2Dead;

    


    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerController>();
        cam = FindObjectOfType<CameraController>();

        if (PlayerPrefs.HasKey("points"))
        {
            setCoins(PlayerPrefs.GetInt("points"));
        }

        if (PlayerPrefs.HasKey("lives"))
        {
            setLives(PlayerPrefs.GetInt("lives"));
        }



        pointText.text = "Points: " + coins;
        battery = 100;
        batteryText.text = "Battery: " + battery + "%";

        respawnPoint = player.transform.position;

        currentLives = startingLives;
        livesText.text = "Lives x " + currentLives;

        currentForm = transformation.robot;
        currentFormString = "base";

        isDead = false;

        hasCigs = false;
        hasKey = false;
        inDialog = false;

        isPaused = false;

        boss2Dead = false;

        //////developer mode
        //unlockTransform("trash can");
        //unlockTransform("mouse");
        //unlockTransform("penguin");
        //////

    }
	
	// Update is called once per frame
	void Update () {

        if (!inDialog)
        {
            if (!isPaused)
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
                if (Input.GetKeyDown("4"))
                {
                    if (transformUnlocks[2] == true)
                        transformPlayer("penguin");
                }
                if (Input.GetKeyDown("5"))
                {
                    //if (transformUnlocks[3] == true)
                    //    transformPlayer("lizard");
                }


                if(coinBonusLifeCount >= 20)
                {
                    addLives(1);
                    coinBonusLifeCount = 0;
                }


                if (Input.GetKeyDown("0"))
                {

                    player.transform.position = respawnPoint;
                    setBattery(100);
                }
            }
        }

    }

    public void respawn()
    {
        currentLives -= 1;
        livesText.text = "Lives x" + currentLives;
        setBattery(100);
        setCoins(0);
        coinBonusLifeCount = 0;

        if (currentLives > 0)
        {
            StartCoroutine("RespawnCo");
        }
        else
        {
            isDead = true;
            player.gameObject.SetActive(false);
            gameOverScreen.SetActive(true);
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
        isDead = false;
        transformPlayer("base");
        yield return null;
    }

    public void addCoins(int amount)
    {
        coins += amount;
        coinBonusLifeCount += amount;
        pointText.text = "Points: " + coins;
        coinSound.Play();
    }

    public void setCoins(int amount)
    {
        coins = amount;
        pointText.text = "Points: " + coins;
    }

    public void addLives(int amount)
    {
        currentLives += amount;
        livesText.text = "Lives x" + currentLives;
        coinSound.Play();
    }

    public void setLives(int amount)
    {
        currentLives = amount;
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

        if(amount > 0)
        {
            BatterySound.Play();
        }
        
    }

    public void setBattery(int amount)
    {
        battery = amount;

        batteryText.text = "Battery: " + battery + "%";
    }

    public void unlockTransform(string type)
    {
        foundTransformSound.Play();
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
                penguinIcon.SetActive(true);
                break;

            case "lizard":
                transformUnlocks[3] = true;
                break;

        }
    }

    public void resetPlayer()
    {
        setBattery(100);
    }



    public void transformPlayer(string type)
    {

        if ((!isDead) && type != currentFormString)
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

            currentFormString = type;

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
                    currentForm = transformation.mouse;
                    addBattery(-5);
                    break;

                case "penguin":
                    Instantiate(penguinPlayer, player.gameObject.transform.position, player.gameObject.transform.rotation);
                    currentForm = transformation.penguin;
                    addBattery(-10);
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
