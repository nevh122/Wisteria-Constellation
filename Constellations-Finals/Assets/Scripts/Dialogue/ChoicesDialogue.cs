using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChoicesDialogue : MonoBehaviour
{

    DialogueManager diagManager;
    NPCInteractEvent ObjectDialogue;
    public GameObject ChoicesUI;
    public GameObject InteractionRange;
    NPCDialogue DefaultDialogue;
    Animator DialogueAnimator;

    public TMP_Text button1, button2, ChoicesQuestion;
    [SerializeField] string button1Text, button2Text, ChoicesQuestionText;
    public DialogueBoxElements button1Picked, button2Picked;
    bool hasPicked = false;
    int buttonPicked = 0;
    private void Start()
    {
        button1.text = button1Text;
        button2.text = button2Text;
        ChoicesQuestion.text = ChoicesQuestionText;

        diagManager = FindObjectOfType<DialogueManager>();
        ObjectDialogue = InteractionRange.GetComponent<NPCInteractEvent>();
        DefaultDialogue = gameObject.GetComponent<NPCDialogue>();
        DialogueAnimator = ChoicesUI.GetComponent<Animator>();
    }
    private void Update()
    {
        if (hasPicked) PlayerHasPickedDialogue();
        else StartChoicesPicker();
            
    }

    //initiates Choices UI;
    void StartChoicesPicker()
    {
        if (diagManager.isDone && ObjectDialogue.isInside && diagManager.hasInteracted && hasPicked == false)
        {
            DialogueAnimator.SetBool("IsOpen",true);
        }
        else
        {
            DialogueAnimator.GetComponent<Animator>().SetBool("IsOpen",false);
        }
    }

    //What buttons does when interacted
    public void Choice1Button()
    {
        DialogueAnimator.SetBool("IsOpen", false);
        FindObjectOfType<DialogueManager>().StartDialogue(button1Picked);
        hasPicked = true;
        buttonPicked = 1;
    }
    public void Choice2Button()
    {
        DialogueAnimator.SetBool("IsOpen", false);
        FindObjectOfType<DialogueManager>().StartDialogue(button2Picked);
        hasPicked = true;
        buttonPicked = 2;
    }

    //When player intearcts with NPC again will change base on what the player has chosen
    public void PlayerHasPickedDialogue()
    {
        switch (buttonPicked)
        {
            case 1:
                DefaultDialogue.dialogue = button1Picked;
                break;
            case 2:
                DefaultDialogue.dialogue = button2Picked;
                break;
            default: break;
        }
    }
}
