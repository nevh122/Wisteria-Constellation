using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LakeKeyGet : MonoBehaviour
{
    PlayerController playerController;
    [SerializeField] DialogueBoxElements LakeKeyDialogue;
    DialogueManager dialogueManager;
    [SerializeField] NPCInteractEvent LakeKeyInteractRange;
    bool hasLakeKey;
    public AudioSource itemPickUp;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    //when player interacts with moon key
    private void Update()
    {
        if (dialogueManager.hasInteracted == true && LakeKeyInteractRange.isInside == true && hasLakeKey == false)
        {
            gameObject.SetActive(false);
            hasLakeKey = true;
            itemPickUp.Play();
        }
    }

    public void GiveLakeKey()
    {
        dialogueManager.StartDialogue(LakeKeyDialogue);
        playerController.LakeKey = true;
        playerController.inventoryText.text += "\n - Lake Key";
    }
}
