using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISounds : MonoBehaviour
{
    public AudioSource buttonPress;
    public AudioSource itemDiscover;
    public AudioSource teleport;

    public void PlayButtonPressed()
    {
        buttonPress.Play();
    }
    public void PlayItemDiscover()
    {
        itemDiscover.Play();
    }
    public void PlayTeleport()
    {
        teleport.Play();
    }
}
