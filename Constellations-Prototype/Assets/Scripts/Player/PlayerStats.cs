using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Contains any stat related to the player at any given moment, to be called by other scripts;
public class PlayerStats : MonoBehaviour
{
    public float PlayerSanity = 50f;

    public void Update()
    {
        //Makes sure that sanity does not exceed 50 and does not go below 0
        PlayerSanity = Mathf.Clamp(PlayerSanity, 0f, 50f);
    }
}
