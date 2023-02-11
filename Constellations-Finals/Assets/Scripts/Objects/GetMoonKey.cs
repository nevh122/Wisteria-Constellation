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
    bool hasMoonkey;
    public AudioSource itemPickUp;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    //when player interacts with moon key
    private void Update()
    {
        if(dialogueManager.hasInteracted == true && MoonKeyInteractRange.isInside == true && hasMoonkey == false)
        {
            gameObject.SetActive(false);
            hasMoonkey = true;
            itemPickUp.Play();
        }
    }

    public void GiveMoonKey()
    {
        dialogueManager.StartDialogue(MoonKeyDialogue);
        playerController.GalaxyKey = true;
        playerController.inventoryText.text += "\n - Galaxy Key";
    }
}
