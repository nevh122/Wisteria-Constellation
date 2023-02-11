using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Checkpoint dialogue before part 2
public class Chapter1Checkpoint : MonoBehaviour
{
    DialogueManager manager;
    public DialogueBoxElements CheckpointDialogue;
    private bool playerHasPassed = false;

    private void Start()
    {
        manager = FindObjectOfType<DialogueManager>();
    }

    public void Update()
    {
        if(manager.isDone && manager.hasInteracted && playerHasPassed)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && playerHasPassed == false)
        {
            playerHasPassed = true;
            TriggerDialogue();
        }
    }
        
    public void TriggerDialogue()
    {
        manager.StartDialogue(CheckpointDialogue);
    }
}
