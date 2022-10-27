using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EncounterChecker : MonoBehaviour
{
    public Camera MainCamera;
    public Camera EncounterCamera;

    public Image TransitionImage;
    public Animator TransitionAnimation;

    public GameObject EncounterPlayer;
    public GameObject EPSpawn;

    public bool inEncounter = false;
    public PlayerStats playerStats;
    public GameObject Player;
    

    //Checks if player is in 0 sanity or in encounter, makes the encounter trigger when needed 
    public void Update()
    {
        if (playerStats.PlayerSanity == 0 && inEncounter == false)
        {
            inEncounter = true;
            StartCoroutine(SanityGame());
        }
    }
    IEnumerator SanityGame()
    {
        Player.gameObject.GetComponent<PlayerController>().enabled = false;
        Player.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        TransitionAnimation.SetBool("Fade", true);
        yield return new WaitUntil(() => TransitionImage.color.a == 1);
        MainCamera.enabled = false;

        EncounterPlayer.transform.position = EPSpawn.transform.position;
        EncounterCamera.enabled = true;
        TransitionAnimation.SetBool("Fade", false);
        EncounterPlayer.GetComponent<MiniPlayerControl>().enabled = true;
        EncounterPlayer.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    }
}
