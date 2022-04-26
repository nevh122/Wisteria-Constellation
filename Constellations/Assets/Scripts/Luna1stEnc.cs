using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Luna1stEnc : MonoBehaviour
{
    public Text maintxt;
    public SpriteRenderer LunaMain;
    public Sprite LunaHappy;
    public Sprite LunaAngry;
    public GameObject Button1;
    public GameObject Button2;
    public bool isAngry;

    public void YesAnswer()
    {
        maintxt.text = "YEEYY! I knew you can do it!";
        LunaMain.sprite = LunaHappy;
        Button1.SetActive(false);
        Button2.SetActive(false);
        isAngry = false;
    }
    public void NoAnswer()
    {
        maintxt.text = "HUH?! But what happens to the game if you dont finish it?";
        LunaMain.sprite = LunaAngry;
        Button1.SetActive(false);
        Button2.SetActive(false);
        isAngry = true;

    }
    public void OnClose()
    {
        if (isAngry == true)
        {
            maintxt.text = "Dont worry about ill just find someone else to do it.";
        }
        else if(isAngry == false)
        {
            maintxt.text = "I knew I can count on you! I believe in you!";
        }
    }
}
