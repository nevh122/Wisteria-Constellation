using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


//Calls other scripts connected to the player, used to avoid script contradictions when adding features
public class PlayerController : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public bool Sunkey;
    public bool StarKey;
    public bool WithJanus;
    public bool MoonKey;
    public bool CloverLeaf;

    public TextMeshProUGUI inventoryText;
    public Animator DeathTransition;   

    public ChoicesDialogue choicesDialogue;
    public DialogueManager dialogueManager;
    public CodePuzzleInput puzzleInput;

    void Update()
    {
        if (choicesDialogue.isActive || dialogueManager.isActive || puzzleInput.isOpen)
        {
            playerMovement.enabled = false;
        }
        else if(choicesDialogue.isActive == false || dialogueManager.isActive == false || puzzleInput.isOpen == false)
        {
            playerMovement.enabled = true;
        }
    }
    //called by other scripts when player has died
    public void CheckPlayerDead()
    {
        DeathTransition.SetTrigger("Transition");
    }
}
