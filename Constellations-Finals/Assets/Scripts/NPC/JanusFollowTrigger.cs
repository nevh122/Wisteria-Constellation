using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JanusFollowTrigger : MonoBehaviour
{
    DialogueManager dialogueManager;
    [SerializeField] GameObject JanusInteractionRange;
    NPCInteractEvent JanusInteractEvent;
    PlayerController playerController;
    public AudioSource itemPickUp;
    
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
            itemPickUp.Play();
            playerController.inventoryText.text += "\n - Janus";
            playerController.WithJanus = true;
            isFollowing = true;
            dialogueManager.hasInteracted = false;
        }
        else return;
    }
}
