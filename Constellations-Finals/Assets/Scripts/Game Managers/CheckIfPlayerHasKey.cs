using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


//Checks if player has necessary key to progress
public class CheckIfPlayerHasKey : MonoBehaviour
{
    PlayerController playerController;
    [SerializeField] DialogueBoxElements dialogueIfLocked;
    public UnityEvent IfPlayerHasAMissingItem;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            IfPlayerHasAMissingItem.Invoke();
        }
        else return;
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Invoke("CloseDialogue", 1);
        }
        else return;
    }
    public void CloseDialogue()
    {
        FindObjectOfType<DialogueManager>().EndDialogue();
    }

    //to be called by a specific door
    public void SunKey()
    {
        if (playerController.Sunkey == true)
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
        else if (playerController.Sunkey == false)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogueIfLocked);
        }
    }
    public void StarKey()
    {
        if (playerController.StarKey == true)
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
        else if (playerController.StarKey == false)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogueIfLocked);
        }
    }
    public void WithJanus()
    {
        if (playerController.WithJanus == true)
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
        else if (playerController.WithJanus == false)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogueIfLocked);
        }
    }
}
