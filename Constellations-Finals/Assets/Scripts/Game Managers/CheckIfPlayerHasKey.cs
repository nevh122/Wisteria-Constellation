using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


//Checks if player has necessary key to progress
public class CheckIfPlayerHasKey : MonoBehaviour
{
    public PlayerController playerController;
    [SerializeField] DialogueBoxElements dialogueIfLocked;
    public UnityEvent IfPlayerHasAMissingItem;
    public GameObject ePrompt;

    //used to attach script to a door
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            ePrompt.SetActive(false);
            IfPlayerHasAMissingItem.Invoke();
            StartCoroutine(CloseDialogue());
        }
    }
    IEnumerator CloseDialogue()
    {
        yield return new WaitForSeconds(2f);
        FindObjectOfType<DialogueManager>().EndDialogue();
        FindObjectOfType<DialogueManager>().hasInteracted = false;
        ePrompt.SetActive(true);
    }

    //to be called by a specific door
    public void SunKey()
    {
        if (playerController.Labyrinthkey == true)
        {
            gameObject.GetComponent<RoomTeleport>().enabled = true;
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
        else if (playerController.Labyrinthkey == false)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogueIfLocked);
        }
    }
    public void StarKey()
    {
        if (playerController.MapleKey == true)
        {
            gameObject.GetComponent<RoomTeleport>().enabled = true;
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
        else if (playerController.MapleKey == false)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogueIfLocked);
        }
    }
    public void WithJanus()
    {
        if (playerController.WithJanus == true)
        {
            gameObject.GetComponent<RoomTeleport>().enabled = true;
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
        else if (playerController.WithJanus == false)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogueIfLocked);
        }
    }
    public void MoonKey()
    {
        if (playerController.GalaxyKey== true)
        {
            gameObject.GetComponent<RoomTeleport>().enabled = true;
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
        else if (playerController.GalaxyKey == false)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogueIfLocked);
        }
    }
}
