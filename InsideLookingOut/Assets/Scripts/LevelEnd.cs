using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour {

    private LevelManager lvlManager;
    public string levelToLoad;

    // Use this for initialization
    void Start()
    {
        lvlManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update () {
		
	}


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {

            PlayerPrefs.SetInt("points", lvlManager.coins);
            PlayerPrefs.SetInt("lives", lvlManager.currentLives);

            switch (levelToLoad)
            {

                case "boss1":
                    if (lvlManager.hasKey)
                    {
                        SceneManager.LoadScene(levelToLoad);
                    }
                    break;



                case "boss2":
                    if (lvlManager.hasLevel2Key)
                    {
                        SceneManager.LoadScene(levelToLoad);
                    }
                    break;



                default:
                    SceneManager.LoadScene(levelToLoad);
                break;
            }
        }
    }
}
