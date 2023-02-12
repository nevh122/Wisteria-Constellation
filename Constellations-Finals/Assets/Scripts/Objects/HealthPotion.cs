using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//restores health to the player when it is less than 3
public class HealthPotion : MonoBehaviour
{
    PlayerController playerController;
    [SerializeField] DialogueBoxElements healthPickUp;
    [SerializeField] DialogueBoxElements examineHealthPotion;
    DialogueManager dialogueManager;
    [SerializeField] NPCInteractEvent PotionInteractRange;
    bool hasPickedUp = false;
    public AudioSource itemPickUp;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    //when player interacts with moon key
    private void Update()
    {
        if (dialogueManager.hasInteracted == true && PotionInteractRange.isInside == true && hasPickedUp == true)
        {
            gameObject.SetActive(false);
            hasPickedUp = false;
            itemPickUp.Play();
        }
    }

    public void TakeHealthPotion()
    {
        if(playerController.playerlives >= 3)
        {
            dialogueManager.StartDialogue(examineHealthPotion);
        }
        else if(playerController.playerlives < 3)
        {
            dialogueManager.StartDialogue(healthPickUp);
            playerController.playerlives = 3;
            hasPickedUp = true;
        }
    }
}
