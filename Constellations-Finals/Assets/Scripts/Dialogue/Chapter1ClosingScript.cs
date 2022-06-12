using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Closing dialogue for chapter 1 trigger
public class Chapter1ClosingScript : MonoBehaviour
{
    DialogueManager manager;
    PlayerController controller;
    public DialogueBoxElements EndDialogue;
    bool thisScript = false;
    public Animator Transition;
    bool isInside = false;
    private void Start()
    {
        manager = FindObjectOfType<DialogueManager>();
        controller = FindObjectOfType<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            controller.enabled = false;
            manager.StartDialogue(EndDialogue);
            thisScript = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        isInside = true;
    }
    private void Update()
    {
        if (isInside)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                manager.DisplayNextDialogue();
            }
        }
        
        if (thisScript && manager.isDone && manager.hasInteracted)
        {
            Transition.SetTrigger("Transition");
            manager.hasInteracted = false;
        }
    }
}
