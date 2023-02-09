using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EPromptBlink : MonoBehaviour
{
    public Image ePrompt;
    public Image Arrow;

    public float FadeInTime = 0.5f;
    public float StayTime = 0.8f;
    public float FadeOutTime = 0.7f;
    public float TimeBetweenFade = 0;
    public Color TextColor;

    void Update()
    {
        TimeBetweenFade += Time.deltaTime;
        if(TimeBetweenFade < FadeInTime)
        {
            ePrompt.color = new Color(TextColor.r, TextColor.g, TextColor.b, TimeBetweenFade / FadeInTime);
            Arrow.color = new Color(TextColor.r, TextColor.g, TextColor.b, TimeBetweenFade / FadeInTime);
        }
        else if(TimeBetweenFade < FadeInTime + StayTime)
        {
            ePrompt.color = new Color(TextColor.r, TextColor.g, TextColor.b, 1);
            Arrow.color = new Color(TextColor.r, TextColor.g, TextColor.b, 1);
        }
        else if (TimeBetweenFade < FadeInTime + StayTime + FadeOutTime)
        {
            ePrompt.color = new Color(TextColor.r, TextColor.g, TextColor.b, 1 - (TimeBetweenFade -(FadeInTime + StayTime))/FadeOutTime);
            Arrow.color = new Color(TextColor.r, TextColor.g, TextColor.b, 1 - (TimeBetweenFade - (FadeInTime + StayTime)) / FadeOutTime);
        }
        else
        {
            TimeBetweenFade = 0;
        }
    }
}
