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

    void Start()
    {
        diagManager = FindObjectOfType<DialogueManager>();
        ObjectDialogue = InteractionRange.GetComponent<NPCInteractEvent>();
    }
    private void Update()
    {
        StartCodeInput();
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
        if(PlayerInput.text == CorrectCode)
        {
            CodeIsCorrect = true;
        }
    }
}
