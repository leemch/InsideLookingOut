using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc1Script : MonoBehaviour {

    public LevelManager lvlManager;
    public dialogue startDialog;
    public dialogue hasCigsdialogue;
    
    public bool gaveCigs = false;

    void Start()
    {
        lvlManager = FindObjectOfType<LevelManager>();
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!gaveCigs)
            {
                if (lvlManager.hasCigs)
                {
                    lvlManager.hasKey = true;
                    lvlManager.talkSound.Play();
                    FindObjectOfType<dialogueManager>().StartDialogue(hasCigsdialogue);
                    gaveCigs = true;
                }
                else
                {
                    
                    FindObjectOfType<dialogueManager>().StartDialogue(startDialog);
                }
            }
        }
    }
}
