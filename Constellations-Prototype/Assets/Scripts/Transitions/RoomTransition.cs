using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomTransition : MonoBehaviour
{
    Rigidbody2D playerRBody;
    public Vector2 locationEndPoint;
    public Image TransitionImage;
    public Animator TransitionAnimation;
    public GameObject Player;
    public PlayerController playerController;

    private void Start()
    {
        playerRBody = Player.GetComponent<Rigidbody2D>();
    }

    //sensor for teleport
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fade());
        }
        
    }

    //end effect once the player has teleported
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            playerRBody.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
            Player.gameObject.GetComponent<PlayerController>().enabled = true;
            TransitionAnimation.SetBool("Fade", false);
        }
    }

    //Triggers teleport and fade effect, also disables player control when player is teleporting
    IEnumerator Fade()
    {
        Player.gameObject.GetComponent<PlayerController>().enabled = false;
        TransitionAnimation.SetBool("Fade", true);
        playerRBody.constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitUntil(() => TransitionImage.color.a == 1);
        Player.transform.position = locationEndPoint;
    }
}
