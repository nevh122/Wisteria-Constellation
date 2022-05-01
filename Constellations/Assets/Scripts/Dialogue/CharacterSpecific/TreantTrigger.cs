using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public Text inventory;

    private int encounter;
    private bool thisScript;
    private bool isDead;

    private void Start()
    {
        encounter = 0;
    }
    private void Update()
    {
        PlayerChoices();
        ChoiceYes();
        ChoiceNo();
        PlayerDead();
    }
    public void TriggerEncounter()
    {
        thisScript = false;
        manager.IsDone = false;
        choiceMngr.IsDone = false;

        switch (encounter)
        {
            case 0:
                FindObjectOfType<DialogueManager>().StartDialogue(dialogueFirstEncounter);
                encounter = 1;
                CloverLeafIndicator.SetActive(true);
                thisScript = true;
                break;
            case 1:
                FindObjectOfType<DialogueManager>().StartDialogue(returnToTreant);
                thisScript = true;
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
                    thisScript = true;
                    choiceMngr.IsDone = true;
                    break;
                case 0:
                    FindObjectOfType<TreantChoiceManager>().StartChoices(WithoutCloverLeaf);
                    thisScript = true;
                    choiceMngr.IsDone = true;
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
                    encounter = 2;
                    choiceMngr.IsDone = false;
                    thisScript = false;
                    player.StarKey =+ 1;
                    inventory.text = inventory.text + "\n- Star Key";
                    break;
                case 0:
                    FindObjectOfType<DialogueManager>().StartDialogue(YesCloverPendant);
                    choiceMngr.IsDone = false;
                    thisScript = false;
                    isDead = true;
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
    public void PlayerDead()
    {
        if (isDead == true && manager.IsDone == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }
}

