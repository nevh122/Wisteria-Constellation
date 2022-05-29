using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CodePuzzleInput : MonoBehaviour
{
    DialogueManager diagManager;
    public GameObject CodeInputUI;
    NPCInteractEvent ObjectDialogue;
    public GameObject InteractionRange;


    public TextMeshProUGUI PlayerInput;
    public bool CodeIsCorrect;
    public string CorrectCode;

    public DialogueBoxElements CodeFinishedDialogue;
    void Start()
    {
        diagManager = FindObjectOfType<DialogueManager>();
        ObjectDialogue = InteractionRange.GetComponent<NPCInteractEvent>();
    }
    private void Update()
    {
        StartCodeInput();
        CheckCode();
        if (CodeIsCorrect)
        {
            CodeInputComplete();
        }
        else return;
    }

    //Checks when to open and close keypad code input
    void StartCodeInput()
    {
        if(diagManager.isDone && ObjectDialogue.isInside && CodeIsCorrect == false)
        {
            CodeInputUI.SetActive(true);
        }
        else
        {
            CodeInputUI.SetActive(false);
        }
    }

    //Checks if code input is correct
    public void CheckCode()
    {
        if(PlayerInput.text.ToString() == CorrectCode)
        {
            CodeIsCorrect = true;
        }
    }

    //if the input puzzle is complete
    public void CodeInputComplete()
    {
        CodeInputUI.SetActive(false);
        InteractionRange.SetActive(false);
        //Triggers a dialogue when code input is correct
        FindObjectOfType<DialogueManager>().StartDialogue(CodeFinishedDialogue);
    }
}
