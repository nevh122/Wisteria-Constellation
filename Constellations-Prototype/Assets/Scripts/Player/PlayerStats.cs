using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;



//Contains any stat related to the player at any given moment and effects that are associated with them, to be called by other scripts;
public class PlayerStats : MonoBehaviour
{
    public float PlayerSanity = 50f;
    public float MaxSanity = 50f;

    public void Update()
    {
        //Makes sure that sanity does not exceed 50 and does not go below 0
        PlayerSanity = Mathf.Clamp(PlayerSanity, 0f, MaxSanity);
    }
}
