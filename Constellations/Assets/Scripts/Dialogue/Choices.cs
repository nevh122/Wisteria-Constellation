using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Choices
{
    public string choice1,choice2;

    [TextArea(3, 10)]
    public string sentences;
}
