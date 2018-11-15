using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroDialogue : MonoBehaviour {

    public dialogue dialogue;
    public bool triggered = false;

    public void TriggerDialog()
    {
        FindObjectOfType<dialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!triggered)
        {
            triggered = true;
            TriggerDialog();
        }

    }
}
