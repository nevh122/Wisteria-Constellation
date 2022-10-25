using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityAccumulation : MonoBehaviour
{
    public Image SanityScreen;
    public PlayerStats playerStats;
    public Animator SanityAnim;

    //Use these to adjust threshholds of sanity
    public float SanityHigh;
    public float SanityHalf;
    public float SanityLow;

    //Reduce sanity when player is in restricted zones
    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
           playerStats.PlayerSanity = playerStats.PlayerSanity - Time.deltaTime;
        }
    }

    //Animation to tell the player that his sanity is getting lower
    void Update()
    {
        if(playerStats.PlayerSanity > SanityHigh)
        {
            SanityAnim.SetInteger("SanityLevel", 0);
        }
        else if(playerStats.PlayerSanity < SanityHigh & playerStats.PlayerSanity > SanityHalf)
        {
            SanityAnim.SetInteger("SanityLevel", 1);
        }
        else if(playerStats.PlayerSanity < SanityHalf & playerStats.PlayerSanity > SanityLow)
        {
            SanityAnim.SetInteger("SanityLevel", 2);
        }
        else if (playerStats.PlayerSanity > SanityLow)
        {
            SanityAnim.SetInteger("SanityLevel", 3);
        }
    }
}
