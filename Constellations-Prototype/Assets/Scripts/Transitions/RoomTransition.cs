using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomTransition : MonoBehaviour
{
    public Vector2 locationEndPoint;
    public Image TransitionImage;
    public Animator TransitionAnimation;
    public GameObject Player;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fade());
        }
        
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            TransitionAnimation.SetBool("Fade", false);
        }
    }

    IEnumerator Fade()
    {
        TransitionAnimation.SetBool("Fade", true);
        yield return new WaitUntil(() => TransitionImage.color.a == 1);
        Player.transform.position = locationEndPoint;
    }
}
