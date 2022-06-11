using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JanusFollowTrigger : MonoBehaviour
{
    DialogueManager dialogueManager;
    [SerializeField] GameObject JanusInteractionRange;
    NPCInteractEvent JanusInteractEvent;
    PlayerController playerController;
    
    bool isFollowing = false;

    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        JanusInteractEvent = JanusInteractionRange.GetComponent<NPCInteractEvent>();
        playerController = FindObjectOfType<PlayerController>();
    }

    //makes Janus follow the player after talking to him
    private void Update()
    {
        if (isFollowing == false && dialogueManager.hasInteracted == true && JanusInteractEvent.isInside && true)
        {
            GetComponent<FollowPlayer>().enabled = true;
            GetComponent<CircleCollider2D>().enabled = false;
            JanusInteractionRange.SetActive(false);
            playerController.inventoryText.text += "\n - Janus";
            playerController.WithJanus = true;
            isFollowing = true;
        }
        else return;
    }
}
