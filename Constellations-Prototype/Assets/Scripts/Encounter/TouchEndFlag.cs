using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchEndFlag : MonoBehaviour
{
    public GameObject miniPlayer;
    public Animator TransitionAnimation;
    public Image TransitionImage;

    public Camera MainCamera;
    public Camera EncounterCamera;

    public GameObject Player;
    public EncounterChecker encounterChecker;

    //Teleports player out of encounter and back to main game with full sanity when they collide with the end flag;
    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("miniPlayer"))
        {
            StartCoroutine(PlayerEscape());
        }
    }
    IEnumerator PlayerEscape()
    {
        miniPlayer.gameObject.GetComponent<MiniPlayerControl>().enabled = false;
        miniPlayer.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        TransitionAnimation.SetBool("Fade", true);
        yield return new WaitUntil(() => TransitionImage.color.a == 1);
        EncounterCamera.enabled = false;

        Player.GetComponent<PlayerStats>().PlayerSanity = 50f;
        encounterChecker.inEncounter = false;
        MainCamera.enabled = true;
        Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
        Player.GetComponent<PlayerController>().enabled = true;
        TransitionAnimation.SetBool("Fade", false);
    }
}
