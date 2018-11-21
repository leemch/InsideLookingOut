using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc2Script : MonoBehaviour {

    public LevelManager lvlManager;
    public dialogue startDialog;
    public dialogue hasSandwichDialog;
    bool hasTalked;
    
    public bool gaveSandwich = false;

    void Start()
    {
        lvlManager = FindObjectOfType<LevelManager>();
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!gaveSandwich)
            {
                if (lvlManager.hasSandwich)
                {
                    lvlManager.addLives(3);
                    FindObjectOfType<dialogueManager>().StartDialogue(hasSandwichDialog);
                    gaveSandwich = true;
                }
                else
                {
                    if (!hasTalked)
                    {
                        hasTalked = true;
                        FindObjectOfType<dialogueManager>().StartDialogue(startDialog);
                    }
                }
            }
        }
    }
}
