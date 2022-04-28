using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public GameObject player;
    public Text dialogueText;
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
    public void StartDialogue(Dialogue dialogue)
    {
        DiagBox.SetBool("IsOpen", true);
        sentences.Clear();
        names.Clear();
        icons.Clear();
        foreach (string name in dialogue.NPCName)
        {
            names.Enqueue(name);
        }
        foreach (Sprite icon in dialogue.NPCSprite)
        {
            icons.Enqueue(icon);
        }
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextDialogue();
    }
    public void DisplayNextDialogue()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        string name = names.Dequeue();
        Sprite icon = icons.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        nameText.text = name;
        NPCIco.sprite = icon;
    }
    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    void EndDialogue()
    {
        player.GetComponent<PlayerController>().enabled = true;
        DiagBox.SetBool("IsOpen", false);
    }
}
