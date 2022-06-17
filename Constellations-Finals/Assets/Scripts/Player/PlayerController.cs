using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


//Calls other scripts connected to the player, used to avoid script contradictions when adding features
public class PlayerController : MonoBehaviour
{
    PlayerMovement playerMovement;
    public bool Sunkey;
    public bool StarKey;
    public bool WithJanus;
    public bool MoonKey;
    public bool CloverLeaf;
    public TextMeshProUGUI inventoryText;
    public Animator DeathTransition;
    TreeNymphChoicesDialogue treeNymph;
    ChoicesDialogue choicesDialogue;
    DialogueManager dialogueManager;
    CodePuzzleInput puzzleInput;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        choicesDialogue = FindObjectOfType<ChoicesDialogue>();
        dialogueManager = FindObjectOfType<DialogueManager>();
        puzzleInput = FindObjectOfType<CodePuzzleInput>();
    }
    void Update()
    {
        if (choicesDialogue.isActive || dialogueManager.isActive || puzzleInput.isOpen)
        {
            playerMovement.playerAnim.SetBool("IsMoving", false);
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        else if(choicesDialogue.isActive == false || dialogueManager.isActive == false || puzzleInput.isOpen == false)
        {
            playerMovement.Move();
        }
    }
    //called by other scripts when player has died
    public void CheckPlayerDead()
    {
        DeathTransition.SetTrigger("Transition");
    }
}
