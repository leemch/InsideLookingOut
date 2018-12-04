using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour {

    public GameObject pauseScreen;

    private PlayerController player;
    private LevelManager lvlManager;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerController>();
        lvlManager = FindObjectOfType<LevelManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0f)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
	}

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseScreen.SetActive(true);
        lvlManager.isPaused = true;
        player.canMove = false;
    }


    public void ResumeGame()
    {
        
        player.canMove = true;
        lvlManager.isPaused = false;
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    public void quitToMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }
}
