using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodeBox : MonoBehaviour
{
    public Dialogue EnterCode;
    public Dialogue Finished;
    public Dialogue CodeAnswered;
    public bool thisScript = false;
    public int encounter = 0;
    public int isSolved;
    public DialogueManager mngr;
    public GameObject InputField;
    public Text PlayerInput;
    public Text inventory;


    public void Start()
    {
        isSolved = 0;
        mngr = FindObjectOfType<DialogueManager>();
    }
    public void Update()
    {
        CodeEnter();
        CodeChecker();
    }
    public void TriggerDialogue()
    {
        switch (encounter)
        {
            case 0:
                FindObjectOfType<DialogueManager>().StartDialogue(EnterCode);
                thisScript = true;
                break;
            case 1:
                FindObjectOfType<DialogueManager>().StartDialogue(Finished);
                thisScript = false;
                break;
            default:
                break;
        }
    }
    public void CodeEnter()
    {
        if (mngr.IsDone == true && thisScript == true)
        {
            switch (isSolved)
            {
                case 1:
                    InputField.SetActive(false);
                    FindObjectOfType<DialogueManager>().StartDialogue(CodeAnswered);
                    encounter = 1;
                    thisScript = false;
                    FindObjectOfType<PlayerController>().SunKey = 1;
                    inventory.text = inventory.text + "\n- Sun Key";
                    break;
                case 0:
                    {
                        InputField.SetActive(true);
                    }
                    break;
            }
        }
    }
    public void CodeChecker()
    {
        if(PlayerInput.text == "9531" && isSolved == 0)
        {
            isSolved = 1;
        }
    }

    public void CloseCodeInput()
    {
        thisScript = false;
    }
}
