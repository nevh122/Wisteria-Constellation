using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText, dialogueText;
    public Image NPCIco;
    private Queue<string> sentences, names;
    private Queue<Sprite> icons;

    public Animator DiagBox;
    void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();
        icons = new Queue<Sprite>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            DisplayNextDialogue();
        }
    }
    public void StartDialogue(DialogueBoxElements dialogue)
    {
        sentences.Clear();
        names.Clear();
        icons.Clear();

        DiagBox.SetBool("IsOpen", true);
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
    }
    public void DisplayNextDialogue()
    {
        if (sentences.Count == 0)
        {
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
        DiagBox.SetBool("IsOpen", false);
    }
}
