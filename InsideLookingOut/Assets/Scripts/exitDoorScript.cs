using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exitDoorScript : MonoBehaviour {

    public LevelManager lvlManager;
    public dialogue startDialog;
    public dialogue hasKeydialogue;


    void Start()
    {
        lvlManager = FindObjectOfType<LevelManager>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

                if (lvlManager.hasKey)
                {
                    FindObjectOfType<dialogueManager>().StartDialogue(hasKeydialogue);
                    SceneManager.LoadScene("boss1");
                }
                else
                {
                    FindObjectOfType<dialogueManager>().StartDialogue(startDialog);
                }
            
        }
    }
}
