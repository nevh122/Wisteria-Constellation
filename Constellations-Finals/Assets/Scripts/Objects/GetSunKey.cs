using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Gives player the sun key after code puzzle
public class GetSunKey : MonoBehaviour
{
    CodePuzzleInput MazeChest;
    PlayerController playerController;

    private void Start()
    {
        MazeChest = GetComponent<CodePuzzleInput>();
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if(playerController.Sunkey == false)
        {
            GiveSunKey();
        }
        
    }
    public void GiveSunKey()
    {
        if(MazeChest.CodeIsCorrect == true)
        {
            playerController.Sunkey = true;
        }
    }
}   

