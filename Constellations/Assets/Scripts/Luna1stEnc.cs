using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class Luna1stEnc : MonoBehaviour
{
    public Text maintxt;
    public SpriteRenderer LunaMain;
    public Sprite LunaHappy, LunaAngry;
    public GameObject Button1, Button2;
    public int isAngry = 0;

    public Tile Flowers, Reed;
    public Vector3Int[] tilePos;
    public Tilemap ABgrnd;
    public void YesAnswer()
    {
        maintxt.alignment = TextAnchor.MiddleLeft;
        maintxt.text = "YEEYY! I knew you can do it!";
        LunaMain.sprite = LunaHappy;
        Button1.SetActive(false);
        Button2.SetActive(false);
        isAngry = 1;
    }
    public void NoAnswer()
    {
        maintxt.alignment = TextAnchor.MiddleLeft;
        maintxt.text = "HUH?! But what happens to the game if you dont finish it?";
        LunaMain.sprite = LunaAngry;
        Button1.SetActive(false);
        Button2.SetActive(false);
        isAngry = 2;
    }
    public void OnClose()
    {
        switch (isAngry)
        {
            case 2:
                maintxt.text = "Dont worry about ill just find someone else to do it.";
                break;
            case 1:
                maintxt.text = "I knew I can count on you! I believe in you!";
                break;
            default:
                break;
        }
    }
    public void TileColorLuna()
    {
        for (int i = 0; i < tilePos.Length; i++)
        {
            switch (isAngry)
            {
                case 2:
                    ABgrnd.SetTile(tilePos[i], Reed);
                    break;
                case 1:
                    ABgrnd.SetTile(tilePos[i], Flowers);
                    break;
                default:
                    break;
            }
        }
    }
}
