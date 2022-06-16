using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Closing dialogue for chapter 1 trigger
public class Chapter1ClosingScript : MonoBehaviour
{
    DialogueManager manager;
    public DialogueBoxElements EndDialogue;
    bool thisScript = false;
    public Animator Transition;
    bool isInside = false;
    PauseMenu pauseMenu;
    private void Start()
    {
        manager = FindObjectOfType<DialogueManager>();
        pauseMenu = FindObjectOfType<PauseMenu>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
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
            if (Input.GetKeyDown(KeyCode.E) && pauseMenu == false)
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
