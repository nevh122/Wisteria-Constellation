using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SanityGameEnd : MonoBehaviour
{
    public GameObject EnPlayer;
    public Animator transitionAnim;
    public Image transitionImage;

    public Camera mainCam;
    public Camera encounterCam;

    public GameObject Player;
    public EncounterSystem encounterSystem;

    public Volume sanityEffect;
    Vignette anxietyVignette;

    public GameObject MainBG, EncBG;
    private void Start()
    {
        sanityEffect.profile.TryGet<Vignette>(out anxietyVignette);
    }
    //Teleports player out of encounter and back to main game with full sanity when they collide with the end flag;
    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("EnPlayer"))
        {
            StartCoroutine(PlayerEscape());
        }
    }

    //stops elements of the encounter
    public void StopEncounter()
    {
        EnPlayer.SetActive(false);
        EnPlayer.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        EncBG.SetActive(false);
    }

    //changes values of objects when the encounter is finished
    public void ChangeAnxietyValuesy()
    {
        Player.GetComponent<PlayerController>().anxietyLevel = 0f;
        anxietyVignette.intensity.value = 0f;
        encounterSystem.inEncounter = false;
    }

    //activates main game elements
    public void ReturnToMainGame()
    {
        Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
        Player.GetComponent<PlayerController>().enabled = true;
        Player.GetComponent<PlayerMovement>().enabled = true;
    }

    public IEnumerator PlayerEscape()
    {
        StopEncounter();

        transitionAnim.SetBool("Transition", true);
        yield return new WaitUntil(() => transitionImage.color.a == 1);
        encounterCam.enabled = false;

        ChangeAnxietyValuesy();
 
        mainCam.enabled = true;

        ReturnToMainGame();

        transitionAnim.SetBool("Transition", false);
    }
}
