using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Closing dialogue for chapter 1 trigger
public class Chapter1ClosingScript : MonoBehaviour
{
    DialogueManager manager;
    public DialogueBoxElements EndDialogue;
    bool thisScript = false;
    public Animator Transition;
    public bool isInside = false;
    PlayerMovement playerMovement;
    public GameObject player;

    private void Start()
    {
        manager = FindObjectOfType<DialogueManager>();
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    public void TriggerEndDialogue()
    {
        manager.StartDialogue(EndDialogue);
        thisScript = true;
    }
    public void Update()
    {
        if (thisScript && manager.isDone && manager.hasInteracted)
        {
            GetComponent<NPCInteractEvent>().enabled = false;
            playerMovement.playerAnim.SetBool("IsMoving", false);
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            player.GetComponent<PlayerController>().enabled = false;
            Transition.SetTrigger("Transition");
            manager.hasInteracted = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }
}
