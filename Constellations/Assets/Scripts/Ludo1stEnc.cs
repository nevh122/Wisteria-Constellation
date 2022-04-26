using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class Ludo1stEnc : MonoBehaviour
{
    public Luna1stEnc Luna;
    public Text maintxt;
    public SpriteRenderer LudoMain;
    public GameObject Button1, Button2;
    public Sprite LudoHappy, LudoAngry;
    public Text Option1, Option2;
    public int LudoIsAngry = 0;

    public Tile Flowers, Reed;
    public Vector3Int[] tilePos;
    public Tilemap ABgrnd;
    public void AfterLuna()
    {
        if(Luna.isAngry != 0)
        {
            maintxt.fontSize = 14;
            maintxt.alignment = TextAnchor.UpperLeft;
            Button1.SetActive(true);
            Button2.SetActive(true);
            switch (Luna.isAngry)
            {
                case 2:
                    maintxt.text = "Hey I heard what you said to Luna... Why are you not coming back to coding?";
                    Option1.text = "I dunno I guess Im not just feeling it right now";
                    Option2.text = "Why do you Care?";
                    break;
                case 1:
                    maintxt.text = "Good to hear your back to coding dude. Is there anything I can help with?";
                    Option1.text = "All good I can do this by myself";
                    Option2.text = "Just dont mess up the code will you";
                    break;
                default:
                    break;
            }
        }
    }
    public void LudoAngryOption()
    {
        maintxt.alignment = TextAnchor.MiddleLeft;
        maintxt.fontSize = 16;
        Button1.SetActive(false);
        Button2.SetActive(false);
        switch (Luna.isAngry)
        {
            case 2:
                maintxt.text = "If youre going to be a shmuck about it then so be it";
                LudoIsAngry = 1;
                break;
            case 1:
                maintxt.text = "Uhhhh.. ok whatever";
                LudoIsAngry = 1;
                break;
            default:
                break;
        }
        LudoMain.sprite = LudoAngry;
    }
    public void LudoHappyOption()
    {
        maintxt.alignment = TextAnchor.MiddleLeft;
        maintxt.fontSize = 16;
        Button1.SetActive(false);
        Button2.SetActive(false);
        switch (Luna.isAngry)
        {
            case 2:
                maintxt.text = "Hey dont worry about it. Youll get the hang of it";
                LudoIsAngry = 2;
                break;
            case 1:
                maintxt.text = "ok if you say so but dont be afraid to ask for some help.";
                LudoIsAngry = 2;
                break;
            default:
                break;
        }
        LudoMain.sprite = LudoHappy;
    }
    public void OnClose()
    {
        Luna.isAngry = 0;
        switch (LudoIsAngry)
        {
            case 2:
                maintxt.text = "If you need help dont be afraid to ask";
                break;
            case 1:
                maintxt.text = "Ohhhh.. now youre asking for help? how about no.";
                break;
            default:
                break;
        }
    }
    public void TileColorLudo()
    {
        for (int i = 0; i < tilePos.Length; i++)
        {
            switch (LudoIsAngry)
            {
                case 2:
                    ABgrnd.SetTile(tilePos[i], Flowers);
                    break;
                case 1:
                    ABgrnd.SetTile(tilePos[i], Reed);
                    break;
                default:
                    break;
            }
        }
    }
}
