using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter1OpeningScript : MonoBehaviour
{
    public DialogueBoxElements OpeningDialogue;
    public DialogueManager manager;
    public GameObject self;
    PauseMenu pauseMenu;

    //Starts opening dialogue once the game has started
    public void Start()
    {
        pauseMenu = FindObjectOfType<PauseMenu>();
        Invoke("StartOpeningDialogue", 0);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !pauseMenu.isOpen)
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
