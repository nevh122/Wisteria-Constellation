using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Chapter1OpeningScript : MonoBehaviour
{
    public DialogueBoxElements OpeningDialogue;
    public DialogueManager manager;
    public GameObject self;

    //Starts opening dialogue once the game has started
    public void Start()
    {
        Invoke("StartOpeningDialogue", 0);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            manager.DisplayNextDialogue();
        }

        if(manager.isDone && manager.hasInteracted)
        {
            self.SetActive(false);
            manager.hasInteracted = false;
        }
    }
    public void StartOpeningDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(OpeningDialogue);
    }
}
