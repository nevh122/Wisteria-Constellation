using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlanetPositions : MonoBehaviour
{
    public PlanetSlots[] planetSlots;
    public DialogueBoxElements whenPuzzleisFinished;
    bool PuzzleEnd = false;
    [SerializeField] GameObject ResetButton;
    [SerializeField] GameObject Moonkey;
    public GameObject ePrompt;
    public GameObject player;

    private void Update()
    {
        if (PuzzleIsCorrect() == true && PuzzleEnd == false)
        {
            EndofPuzzle();
        }
    }

    //checks if all planets slots have correct planet in them
    public bool PuzzleIsCorrect()
    {
        for (int i = 0; i < planetSlots.Length; ++i)
        {
            if (planetSlots[i].isRight == false)
            {
                return false;
            }   
        }
        return true;
    }

    //happens when puzzle is finished
    public void EndofPuzzle()
    {
        PuzzleEnd = true;
        FindObjectOfType<DialogueManager>().StartDialogue(whenPuzzleisFinished);
        Moonkey.SetActive(true);
        ResetButton.SetActive(false);
        ePrompt.SetActive(false);
        Invoke("CloseDialogue", 2);
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void CloseDialogue()
    {
        FindObjectOfType<DialogueManager>().EndDialogue();
        FindObjectOfType<DialogueManager>().hasInteracted = false;
        ePrompt.SetActive(true);
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
    }
}
