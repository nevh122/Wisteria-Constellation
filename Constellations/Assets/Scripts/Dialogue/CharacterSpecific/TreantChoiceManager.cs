using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreantChoiceManager : MonoBehaviour
{
    public Text choice1, choice2;
    public GameObject player;
    public Text mainText;
    public DialogueManager manager;

    public Animator ChoiceBox;
    public bool IsDone;
    public int playerPick;

    public void StartChoices(Choices question)
    {
        IsDone = false;
        ChoiceBox.SetBool("IsOpen", true);
        mainText.text = question.sentences;
        choice1.text = question.choice1;
        choice2.text = question.choice2;
        playerPick = 0;
    }
    public void Choice1Button()
    {
        playerPick = 1;
        manager.IsDone = false;
        EndDialogue();
        return;
    }
    public void Choice2Button()
    {
        playerPick = 2;
        manager.IsDone = false;
        EndDialogue();
        return;
    }
    public void EndDialogue()
    {
        ChoiceBox.SetBool("IsOpen", false);
        IsDone = true;
        
    }
}
