using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Gives player moon key when interacted/called by NPCInteractEvent
public class GetMoonKey : MonoBehaviour
{
    PlayerController playerController;
    [SerializeField] DialogueBoxElements MoonKeyDialogue;
    DialogueManager dialogueManager;
    [SerializeField] NPCInteractEvent MoonKeyInteractRange;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    private void Update()
    {
        if(dialogueManager.hasInteracted == true && MoonKeyInteractRange.isInside == true)
        {
            gameObject.SetActive(false);
        }
    }

    public void GiveMoonKey()
    {
        dialogueManager.StartDialogue(MoonKeyDialogue);
        playerController.MoonKey = true;
        playerController.inventoryText.text += "\n - Moon Key";
    }
}
