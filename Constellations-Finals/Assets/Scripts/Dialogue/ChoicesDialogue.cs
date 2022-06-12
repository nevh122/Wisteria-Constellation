using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

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
    public bool hasPicked = false;
    public bool reset = false;

    public UnityEvent WhenButton1Pressed, WhenButton2Pressed;
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
        if (hasPicked == false) StartChoicesPicker();
    }

    //initiates Choices UI;
    void StartChoicesPicker()
    {
        if (diagManager.isDone && ObjectDialogue.isInside && diagManager.hasInteracted && hasPicked == false && reset == false)
        {
            DialogueAnimator.SetBool("IsOpen",true);
        }
        else
        {
            DialogueAnimator.SetBool("IsOpen",false);
        }
    }

    //What buttons does when interacted
    public void Choice1Button()
    {
        DialogueAnimator.SetBool("IsOpen", false);
        WhenButton1Pressed.Invoke();
    }
    public void Choice2Button()
    {
        DialogueAnimator.SetBool("IsOpen", false);
        WhenButton2Pressed.Invoke();
    }
}
