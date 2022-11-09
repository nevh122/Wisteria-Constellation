using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class EnemyChase : MonoBehaviour
{
    public PlayerController playerController;
    public EncounterSystem encounterSystem;
    public GameObject EnPlayer;
    public GameObject Player;
    public float distance;
    public float distanceBetween;
    public float moveSpeed;

    public Volume volume;
    Vignette anxietyVignette;

    public Animator transitionAnim;
    public Image transitionImage;

    public Camera mainCam;
    public Camera encounterCam;
    private void Start()
    {
        volume.profile.TryGet<Vignette>(out anxietyVignette);
    }
    private void Update()
    {
        distance = Vector2.Distance(transform.position, EnPlayer.transform.position);
        Vector2 direction = EnPlayer.transform.position - transform.position;
        if(distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, EnPlayer.transform.position, moveSpeed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("EnPlayer"))
        {
            StartCoroutine(GameEnd());
        }
    }
    IEnumerator GameEnd()
    {
        EnPlayer.SetActive(false);
        EnPlayer.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        transitionAnim.SetBool("Transition", true);
        yield return new WaitUntil(() => transitionImage.color.a == 1);
        encounterCam.enabled = false;

        playerController.anxietyLevel = 0f;
        anxietyVignette.intensity.value = 0f;
        playerController.playerlives -= 1f;
        encounterSystem.inEncounter = false;
        mainCam.enabled = true;
        Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
        Player.GetComponent<PlayerController>().enabled = true;
        Player.GetComponent<PlayerMovement>().enabled = true;
        transitionAnim.SetBool("Transition", false);
    }
}
