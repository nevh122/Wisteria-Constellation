using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gives player clover leaf when interacted/called by NPCInteractEvent
public class GetCloverLeaf : MonoBehaviour
{
    PlayerController playerController;
    [SerializeField] DialogueBoxElements CloverLeafDialogue;
    DialogueManager dialogueManager;
    [SerializeField] NPCInteractEvent CloverLeafInteractRange;
    public AudioSource itemPickUp;

    //When player interacts with clover leaf
    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    private void Update()
    {
        if (dialogueManager.hasInteracted == true && CloverLeafInteractRange.isInside == true)
        {
            gameObject.SetActive(false);
        }
    }

    public void GiveCloverLeaf()
    {
        dialogueManager.StartDialogue(CloverLeafDialogue);
        playerController.CloverLeaf = true;
        itemPickUp.Play();
        playerController.inventoryText.text += "\n - Clover Leaf";
    }
}
