using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeNymphChoicesDialogue : MonoBehaviour
{
    PlayerController playerController;
    public DialogueBoxElements YesCloverLeaf, YesPendant, NoDialogue, NoDialogueChange, YesDialogueChange;
    NPCDialogue DefaultDialogue;
    ChoicesDialogue TreeNymphChoicesDialogueScript;
    DialogueManager dialogueManager;
    bool KillPlayer = false;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        DefaultDialogue = GetComponent<NPCDialogue>();
        TreeNymphChoicesDialogueScript = GetComponent<ChoicesDialogue>();
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    //Questions for picking during tree nymph dialogue
    private void Update()
    {
        if(playerController.CloverLeaf == true)
        {
            TreeNymphChoicesDialogueScript.ChoicesQuestion.text = "Give Tree Nymph the Clover Leaf?";
        }
        else
        {
            TreeNymphChoicesDialogueScript.ChoicesQuestion.text = "Give Tree Nymph the Pendant?";
        }
        //kills player if using pendant
        if(KillPlayer && dialogueManager.hasInteracted && dialogueManager.isDone)
        {
            playerController.enabled = false;
            playerController.CheckPlayerDead();
            dialogueManager.hasInteracted = false;
        }
    }

    //When choosing yes
    public void Button1Dialogue()
    {
        if(playerController.CloverLeaf == true)
        {
            dialogueManager.StartDialogue(YesCloverLeaf);
            TreeNymphChoicesDialogueScript.hasPicked = true;
            DefaultDialogue.dialogue = YesDialogueChange;
            playerController.inventoryText.text += "\n - Star Key";
            playerController.StarKey = true;
            dialogueManager.hasInteracted = false;
        }
        else
        {
            dialogueManager.StartDialogue(YesPendant);
            TreeNymphChoicesDialogueScript.hasPicked = true;
            KillPlayer = true;
            dialogueManager.hasInteracted = false;
        }
    }

    //When choosing no
    public void Button2Dialogue()
    {
        if (playerController.CloverLeaf == true)
        {
            dialogueManager.StartDialogue(NoDialogue);
            TreeNymphChoicesDialogueScript.hasPicked = false;
            DefaultDialogue.dialogue = NoDialogueChange;
            TreeNymphChoicesDialogueScript.reset = true;
            dialogueManager.hasInteracted = false;
        }
        else
        {
            dialogueManager.StartDialogue(NoDialogue);
            TreeNymphChoicesDialogueScript.hasPicked = false;
            DefaultDialogue.dialogue = NoDialogueChange;
            TreeNymphChoicesDialogueScript.reset = true;
            dialogueManager.hasInteracted = false;
        }
    }
    //to reset choices picker after choosing no
    public void ResetChoices()
    {
        TreeNymphChoicesDialogueScript.reset = false;
    }
}
