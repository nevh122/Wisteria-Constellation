using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreSanity : MonoBehaviour
{
    public PlayerStats playerStats;


    //restores sanity when player is within the zone
    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            playerStats.PlayerSanity = playerStats.PlayerSanity + Time.deltaTime;
        }
    }
}
