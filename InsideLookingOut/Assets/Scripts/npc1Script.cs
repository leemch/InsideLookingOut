using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc1Script : MonoBehaviour {

    public dialogue dialogue;

    public void TriggerDialog()
    {
        FindObjectOfType<dialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        TriggerDialog();
    }
}
