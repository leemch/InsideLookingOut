using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class dialogueManager : MonoBehaviour {


    public Text nameText;
    public Text dialogueText;

    public Animator anim;
    private Queue<string> sentences;
    public LevelManager lvlManager;


    // Use this for initialization
    void Start () {
        sentences = new Queue<string>();
        lvlManager = FindObjectOfType<LevelManager>();

    }
	

    public void StartDialogue(dialogue dialogue)
    {
        lvlManager.inDialog = true;

        anim.SetBool("isOpen", true);

        nameText.text = dialogue.name;
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        //dialogueText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        lvlManager.inDialog = false; 
        anim.SetBool("isOpen", false);
        Debug.Log("End of Convo");
    }
}
