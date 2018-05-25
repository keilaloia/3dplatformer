using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {

    public Text NameText;
    public Text dialoguetext;

    private Queue<string> Sentences;

	// Use this for initialization
	void Start ()
    {
        Sentences = new Queue<string>();
	}
	
    public void StartDialogue(Dial dialogue)
    {
        NameText.text = dialogue.name;
        Sentences.Clear();

        foreach(string Sentence  in dialogue.sentences)
        {
            Sentences.Enqueue(Sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(Sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = Sentences.Dequeue();
        dialoguetext.text = sentence;
    }

    private void EndDialogue()
    {
        Debug.Log("end of convo");
    }
}
