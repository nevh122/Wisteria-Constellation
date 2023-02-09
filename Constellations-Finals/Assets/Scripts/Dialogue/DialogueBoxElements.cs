using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueBoxElements
{
    //Passed elements to be used by the dialogue manager
    public string[] NPCName;
    public Sprite[] NPCSprite;
    public Sprite[] NPCSprite2;

    [TextArea(3, 10)]
    public string[] NPCDialogue;
}
