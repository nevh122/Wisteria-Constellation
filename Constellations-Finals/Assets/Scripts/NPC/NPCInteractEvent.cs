using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPCInteractEvent : MonoBehaviour
{
    public UnityEvent whenInteracted;
    DialogueManager manager;
    public bool isInside = false;
    PauseMenu pauseMenu;
    ChoicesDialogue choicesDialogue;
    public GameObject indicator;
    CodePuzzleInput puzzleInput;

    void Start()
    {
        manager = FindObjectOfType<DialogueManager>();
        pauseMenu = FindObjectOfType<PauseMenu>();
        choicesDialogue = FindObjectOfType<ChoicesDialogue>();
        puzzleInput = FindObjectOfType<CodePuzzleInput>();
    }

    //if the player press interact button and in range does the following
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInside && pauseMenu.isOpen == false && puzzleInput.isOpen == false)
        {
            if (manager.isDone && choicesDialogue.isActive == false)
            {
                whenInteracted.Invoke();
            }
            else
            {
                manager.DisplayNextDialogue();
            }
        }
    }

    //Checks if the player is within interaction range
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            indicator.SetActive(true);
            isInside = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            indicator.SetActive(false);
            isInside = false;
            manager.EndDialogue();
            manager.hasInteracted = false;
        }
    }
}
