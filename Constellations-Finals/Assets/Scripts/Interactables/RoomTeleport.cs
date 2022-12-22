using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomTeleport : MonoBehaviour
{
    [SerializeField] Vector2 teleportLocation;
    PlayerController playerController;

    Rigidbody2D playerRbody;
    public GameObject Player;

    public Animator transitionAnim;
    public Image transitionImage;

    public AudioSource teleportSound;

    public void Start()
    {
        playerRbody = Player.GetComponent<Rigidbody2D>();
        playerController = Player.GetComponent<PlayerController>();
    }

    //checks if player is stepping on teleporter
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            teleportSound.Play();
            StartCoroutine(StartTeleport());
        }
    }

    //Re enables player movement and control after teleporting
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerRbody.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
            Player.gameObject.GetComponent<PlayerMovement>().enabled = true;
            transitionAnim.SetBool("Transition", false);
            playerController.teleporting = false;
        }
    }

    //teleports player to location and disables movement
    IEnumerator StartTeleport()
    {
        playerController.teleporting = true;
        Player.gameObject.GetComponent<PlayerMovement>().enabled = false;
        transitionAnim.SetBool("Transition", true);
        playerRbody.constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitUntil(() => transitionImage.color.a == 1);
        Player.transform.position = teleportLocation;
    }
}
