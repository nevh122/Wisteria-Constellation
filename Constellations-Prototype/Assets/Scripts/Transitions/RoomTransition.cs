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

    private void Start()
    {
        playerRBody = Player.GetComponent<Rigidbody2D>();
    }

    //sensor for teleport
    void OnTriggerEnter2D(Collider2D col)
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
            //Add better solution to this later since player should not rotate
            playerRBody.constraints = RigidbodyConstraints2D.None;
            TransitionAnimation.SetBool("Fade", false);
        }
    }

    //Triggers teleport and fade effect
    IEnumerator Fade()
    {
        TransitionAnimation.SetBool("Fade", true);
        playerRBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        yield return new WaitUntil(() => TransitionImage.color.a == 1);
        Player.transform.position = locationEndPoint;
    }
}
