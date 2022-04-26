using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ludo1stEnc : MonoBehaviour
{
    public Luna1stEnc Luna;
    public Text maintxt;
    public GameObject Button1;
    public GameObject Button2;
    public Text Option1;
    public Text Option2;

    public void AfterLuna()
    {
        if(Luna.isAngry == true)
        {
            maintxt.fontSize = 14;
            maintxt.text = "Hey I heard what you said to Luna... Why are you not coming back to coding?";
            Button1.SetActive(true);
            Button2.SetActive(true);
            Option1.text = "I dunno I guess Im not just feeling it right now";
            Option2.text = "Why do you Care?";
        }

        if(Luna.isAngry == false)
        {
            maintxt.fontSize = 14;
            maintxt.text = "Good to hear your back to coding dude. Is there anything I can help with?";
            Button1.SetActive(true);
            Button2.SetActive(true);
            Option1.text = "All good I can do this by myself";
            Option2.text = "Just dont mess up the code will you";
        }
    }
   
}
