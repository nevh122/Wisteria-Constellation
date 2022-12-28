using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class EnemyChase : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject EnPlayer;
    public GameObject Player;
    public float distance;
    public float distanceBetween;
    public float moveSpeed;

    public Image transitionImage;

    public SanityGameEnd SanityGameEnd;
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
        StartCoroutine(SanityGameEnd.PlayerEscape());
        playerController.playerlives -= 1f;
        yield return new WaitUntil(() => transitionImage.color.a == 1);
    }
}
