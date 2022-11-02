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

    public TMP_Text button1, button2, ChoicesQuestion;
    [SerializeField] string button1Text, button2Text, ChoicesQuestionText;
    public bool hasPicked = false;
    public bool reset = false;
    public bool isActive = false;

    public UnityEvent WhenButton1Pressed, WhenButton2Pressed;
    private void Start()
    {
        button1.text = button1Text;
        button2.text = button2Text;
        ChoicesQuestion.text = ChoicesQuestionText;

        diagManager = FindObjectOfType<DialogueManager>();
        ObjectDialogue = InteractionRange.GetComponent<NPCInteractEvent>();
        DefaultDialogue = gameObject.GetComponent<NPCDialogue>();
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
            isActive = true;
            ChoicesUI.SetActive(true);
        }
        else
        {
            ChoicesUI.SetActive(false);
        }
    }

    //What buttons does when interacted
    public void Choice1Button()
    {
        isActive = false;
        ChoicesUI.SetActive(false);
        WhenButton1Pressed.Invoke();
    }
    public void Choice2Button()
    {
        isActive = false;
        ChoicesUI.SetActive(true);
        WhenButton2Pressed.Invoke();
    }
}
