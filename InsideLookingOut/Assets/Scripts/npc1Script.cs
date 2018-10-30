using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc1Script : MonoBehaviour {

    public dialogue dialogue;

    public void TriggerDialog()
    {
        FindObjectOfType<dialogueManager>().StartDialogue(dialogue);
    }
}
