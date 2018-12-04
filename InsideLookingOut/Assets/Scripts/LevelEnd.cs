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

            switch (levelToLoad)
            {

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
