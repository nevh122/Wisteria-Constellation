using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeNymphChoicesDialogue : MonoBehaviour
{
    PlayerController playerController;
    public DialogueBoxElements YesCloverLeaf, YesPendant, NoDialogue, NoDialogueChange, YesDialogueChange;
    NPCDialogue DefaultDialogue;
    ChoicesDialogue TreeNymphChoicesDialogueScript;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        DefaultDialogue = GetComponent<NPCDialogue>();
        TreeNymphChoicesDialogueScript = GetComponent<ChoicesDialogue>();
    }

    //Questions for picking during tree nymph dialogue
    private void Update()
    {
        if(playerController.CloverLeaf == true)
        {
            TreeNymphChoicesDialogueScript.ChoicesQuestion.text = "Give Tree Nyph the Clover Leaf?";
        }
        else
        {
            TreeNymphChoicesDialogueScript.ChoicesQuestion.text = "Give Tree Nyph the Pendant?";
        }
    }

    //When choosing yes
    public void Button1Dialogue()
    {
        if(playerController.CloverLeaf == true)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(YesCloverLeaf);
            TreeNymphChoicesDialogueScript.hasPicked = true;
            DefaultDialogue.dialogue = YesDialogueChange;
            playerController.inventoryText.text += "\n - Star Key";
            playerController.StarKey = true;
        }
        else
        {
            FindObjectOfType<DialogueManager>().StartDialogue(YesPendant);
            TreeNymphChoicesDialogueScript.hasPicked = true;
        }
    }

    //When choosing no
    public void Button2Dialogue()
    {
        if (playerController.CloverLeaf == true)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(NoDialogue);
            TreeNymphChoicesDialogueScript.hasPicked = false;
            DefaultDialogue.dialogue = NoDialogueChange;
        }
        else
        {
            FindObjectOfType<DialogueManager>().StartDialogue(NoDialogue);
            TreeNymphChoicesDialogueScript.hasPicked = false;
            DefaultDialogue.dialogue = NoDialogueChange;
        }
    }
}
