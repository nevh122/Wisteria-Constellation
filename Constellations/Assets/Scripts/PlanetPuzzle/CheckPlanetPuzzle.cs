using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlanetPuzzle : MonoBehaviour
{
    public DetectwhenRight[] planetCheckers;
    public Dialogue keydrop;
    public bool isCorect;
    bool PuzzleEnd = false;
    public GameObject MoonKey;

    public void Update()
    {
        GetKey();
    }
    public bool PuzzleIsCorrect()
    {
        for (int i = 0; i < planetCheckers.Length; ++i)
        {
            isCorect = false;
            if (planetCheckers[i].isRight == true)
            {
               isCorect =  true;
            }
            else
                isCorect = false;
        }
        return isCorect;
    }
    public void GetKey()
    {
        if(PuzzleIsCorrect() == true && PuzzleEnd == false)
        {
            PuzzleEnd = true;
            FindObjectOfType<DialogueManager>().StartDialogue(keydrop);
            MoonKey.SetActive(true);
        }
    }
}
