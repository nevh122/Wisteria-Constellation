using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnPlayerSound : MonoBehaviour
{
    public AudioSource left;
    public AudioSource right;

    public void RunLeft()
    {
        left.Play();
    }
    public void RunRight()
    {
        right.Play();
    }
}
