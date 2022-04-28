using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreantTrigger : MonoBehaviour
{
    public Dialogue dialogueFirstEncounter;
    public Dialogue returnToTreant;
    public Choices WithCloverLeaf;
    public Choices WithoutCloverLeaf;
    public Dialogue YesCloverLeaf;
    public Dialogue YesCloverPendant;
    public Dialogue NoAnswer;
    public Dialogue EndOfDialogue;
    public PlayerController player;
    public DialogueManager manager;
    public TreantChoiceManager choiceMngr;
    public GameObject CloverLeafIndicator;

    private int encounter;
    private bool thisScript;

    private void Start()
    {
        encounter = 0;
    }
    private void Update()
    {
        PlayerChoices();
        ChoiceYes();
        ChoiceNo();
    }
    public void TriggerEncounter()
    {
        thisScript = true;
        manager.IsDone = false;
        switch (encounter)
        {
            case 0:
                FindObjectOfType<DialogueManager>().StartDialogue(dialogueFirstEncounter);
                encounter = 1;
                CloverLeafIndicator.SetActive(true);
                break;
            case 1:
                FindObjectOfType<DialogueManager>().StartDialogue(returnToTreant);
                break;
            case 2:
                FindObjectOfType<DialogueManager>().StartDialogue(EndOfDialogue);
                thisScript = false;
                break;
            default: break;
        }
    }
    public void PlayerChoices()
    {
        if (manager.IsDone == true && thisScript == true)
        {
            switch (player.CloverLeaf)
            {
                case 1:
                    FindObjectOfType<TreantChoiceManager>().StartChoices(WithCloverLeaf);
                    encounter = 2;
                    break;
                case 0:
                    FindObjectOfType<TreantChoiceManager>().StartChoices(WithoutCloverLeaf);
                    break;
                default: break;
            }
        }
    }
    public void ChoiceYes()
    {
        if (choiceMngr.IsDone == true && thisScript == true && choiceMngr.playerPick == 1)
        {
            switch (player.CloverLeaf)
            {
                case 1:
                    FindObjectOfType<DialogueManager>().StartDialogue(YesCloverLeaf);
                    choiceMngr.IsDone = false;
                    thisScript = false;
                    break;
                case 0:
                    FindObjectOfType<DialogueManager>().StartDialogue(YesCloverPendant);
                    choiceMngr.IsDone = false;
                    thisScript = false;
                    break;
                default: break;
            }
        }
    }
    public void ChoiceNo()
    {
        if (choiceMngr.IsDone == true && thisScript == true && choiceMngr.playerPick == 2)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(NoAnswer);
            choiceMngr.IsDone = false;
            thisScript = false;
        }
    }
}

