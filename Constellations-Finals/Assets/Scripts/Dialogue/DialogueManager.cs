using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText, dialogueText;
    public Image NPCIco;
    private Queue<string> sentences, names;
    private Queue<Sprite> icons;

    public Animator DiagBox;
    public bool isDone;
    public bool hasInteracted;

    //Clears Queue when starting
    void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();
        icons = new Queue<Sprite>();
    }
    public void StartDialogue(DialogueBoxElements dialogue)
    {
        //Clears Queue when there is a new dialogue set
        isDone = false;
        hasInteracted = false;
        sentences.Clear();
        names.Clear();
        icons.Clear();

        DiagBox.SetBool("IsOpen", true);
        //Enqueues new dialogue
        foreach (string name in dialogue.NPCName)
        {
            names.Enqueue(name);
        }
        foreach (Sprite icon in dialogue.NPCSprite)
        {
            icons.Enqueue(icon);
        }
        foreach (string sentence in dialogue.NPCDialogue)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextDialogue();
    }
    public void DisplayNextDialogue()
    {
        //Dequeue the dilogue in order of the array
        if (sentences.Count == 0)
        {
            //to use by other scripts if the dialogue is done
            hasInteracted = true;

            isDone = true;
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        string name = names.Dequeue();
        Sprite icon = icons.Dequeue();
        dialogueText.text = sentence;
        nameText.text = name;
        NPCIco.sprite = icon;
    }
    public void EndDialogue()
    {
        isDone = true;
        DiagBox.SetBool("IsOpen", false);   
    }
}
