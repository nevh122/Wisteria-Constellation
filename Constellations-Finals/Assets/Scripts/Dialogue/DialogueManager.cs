using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject DialogueUI;
    public TextMeshProUGUI nameText, dialogueText;
    public Image NPCIco, NPCIco2;
    private Queue<string> sentences, names;
    private Queue<Sprite> icons, icons2;

    public bool isDone;
    public bool hasInteracted;
    public bool isActive = false;

    //Clears Queue when starting
    void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();
        icons = new Queue<Sprite>();
        icons2 = new Queue<Sprite>();
    }
    public void StartDialogue(DialogueBoxElements dialogue)
    {
        //Clears Queue when there is a new dialogue set
        isDone = false;
        hasInteracted = false;
        isActive = true;
        sentences.Clear();
        names.Clear();
        icons.Clear();
        icons2.Clear();

        DialogueUI.SetActive(true);
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
        foreach (Sprite icon2 in dialogue.NPCSprite2)
        {
            icons2.Enqueue(icon2);
        }
        DisplayNextDialogue();
    }
    public void DisplayNextDialogue()
    {
        //Dequeue the dilogue in order of the array
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        string name = names.Dequeue();
        Sprite icon = icons.Dequeue();
        Sprite icon2 = icons2.Dequeue();
        dialogueText.text = sentence;
        nameText.text = name;
        NPCIco.sprite = icon;
        NPCIco2.sprite = icon2;
    }

    //to use by other scripts if the dialogue is done
    public void EndDialogue()
    {
        isDone = true;
        hasInteracted = true;
        isActive = false;
        DialogueUI.SetActive(false);   
    }
}
