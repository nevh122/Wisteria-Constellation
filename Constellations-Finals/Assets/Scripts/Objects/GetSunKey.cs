using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Gives player the sun key after code puzzle
public class GetSunKey : MonoBehaviour
{
    CodePuzzleInput MazeChest;
    PlayerController playerController;
    SpriteRenderer BoxSprite;
    public Sprite BoxIsOpenSprite;

    private void Start()
    {
        MazeChest = GetComponent<CodePuzzleInput>();
        playerController = FindObjectOfType<PlayerController>();
        BoxSprite = GetComponent<SpriteRenderer>();
    }

    //when player interacts with sun key
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
            BoxSprite.sprite = BoxIsOpenSprite;
            playerController.inventoryText.text += "\n - Sun Key";
            playerController.Sunkey = true;
        }
    }
}   

