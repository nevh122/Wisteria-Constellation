using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Contains any stat related to the player at any given moment and effects that are associated with them, to be called by other scripts;
public class PlayerStats : MonoBehaviour
{
    public float PlayerSanity = 50f;
    public Image TransitionImage;
    public Animator TransitionAnimation;

    public Camera MainCamera;
    public Camera EncounterCamera;

    public GameObject EncounterPlayer;
    public GameObject EPSpawn;

    public bool inEncounter = false;
    public void Update()
    {
        //Makes sure that sanity does not exceed 50 and does not go below 0
        PlayerSanity = Mathf.Clamp(PlayerSanity, 0f, 50f);

        //triggers sanity mini game
        if (PlayerSanity == 0 && inEncounter == false)
        {
            inEncounter = true;
            StartCoroutine(SanityGame());
        }
    }

    IEnumerator SanityGame()
    {
        gameObject.GetComponent<PlayerController>().enabled = false;
        TransitionAnimation.SetBool("Fade", true);
        yield return new WaitUntil(() => TransitionImage.color.a == 1);
        MainCamera.enabled = false;
        EncounterPlayer.GetComponent<MiniPlayerControl>().enabled = true;
        EncounterCamera.enabled = true;
        EncounterPlayer.transform.position = EPSpawn.transform.position;
        TransitionAnimation.SetBool("Fade", false);
    }
}
