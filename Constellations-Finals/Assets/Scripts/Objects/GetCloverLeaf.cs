using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gives player clover leaf when interacted/called by NPCInteractEvent
public class GetCloverLeaf : MonoBehaviour
{
    PlayerController playerController;
    [SerializeField] DialogueBoxElements CloverLeafDialogue;
    [SerializeField] DialogueBoxElements WhenPlayerHasCloverAlready;
    DialogueManager dialogueManager;
    [SerializeField] NPCInteractEvent CloverLeafInteractRange;
    public AudioSource itemPickUp;
    private bool CheckCloverLeaf = false;

    //When player interacts with clover leaf
    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    private void Update()
    {
        if (dialogueManager.hasInteracted == true && playerController.CloverLeaf == true && CheckCloverLeaf == true)
        {
            CheckCloverLeaf = false;
            itemPickUp.Play();
            gameObject.SetActive(false);
        }
    }

    public void GiveCloverLeaf()
    {
        if(playerController.CloverLeaf == false)
        {
            CheckCloverLeaf = true;
            dialogueManager.StartDialogue(CloverLeafDialogue);
            playerController.CloverLeaf = true;
            playerController.inventoryText.text += "\n - Clover Leaf";
        }
        else if (playerController.CloverLeaf == true)
        {
            CheckCloverLeaf = false;
            dialogueManager.StartDialogue(WhenPlayerHasCloverAlready);
        }
    }
}
