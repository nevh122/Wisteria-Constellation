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
    NPCDialogue DefaultDialogue;
    public GameObject InteractionRange;

    public TMP_InputField PlayerInput;
    public bool CodeIsCorrect;
    public bool isOpen = false;
    public string CorrectCode = "";
    bool CodeInputDone = true;
    bool ChangeDialogue;
    PauseMenu pauseMenu;

    public DialogueBoxElements CodeFinishedDialogue;
    public DialogueBoxElements InteractAgainWhileFinished;
    void Start()
    {
        diagManager = FindObjectOfType<DialogueManager>();
        ObjectDialogue = InteractionRange.GetComponent<NPCInteractEvent>();
        DefaultDialogue = gameObject.GetComponent<NPCDialogue>();
        pauseMenu = FindObjectOfType<PauseMenu>();
    }
    private void Update()
    {
        StartCodeInput();
        CheckCode();
        if (CodeIsCorrect)
        {
            CodeInputComplete();
        }
        if(CodeInputDone == false)
        {
            NewDialogueAfterCompletion();
        }
    }

    //Checks when to open and close keypad code input
    void StartCodeInput()
    {
        if (diagManager.isDone && ObjectDialogue.isInside && CodeIsCorrect == false && diagManager.hasInteracted && pauseMenu.isOpen == false)
        {
            CodeInputUI.SetActive(true);
            isOpen = true;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isOpen = false;
                CodeInputUI.SetActive(false);
                diagManager.hasInteracted = false;
            }
        }
        else
        {
            isOpen = false;
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

    //if the input puzzle is complete
    public void CodeInputComplete()
    {
        if (CodeInputDone)
        {
            CodeInputUI.SetActive(false);
            //Triggers a dialogue when code input is correct
            FindObjectOfType<DialogueManager>().StartDialogue(CodeFinishedDialogue);
            CodeInputDone = false;
            ChangeDialogue = true;
        }
    }

    //Dialogue after completing the code puzzle
    public void NewDialogueAfterCompletion()
    {
        if (ChangeDialogue)
        {
            DefaultDialogue.dialogue = InteractAgainWhileFinished;
        }
    }
}
