using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteReOrderer : MonoBehaviour
{
    public SpriteRenderer spriteToChange;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            spriteToChange.sortingOrder = 1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            spriteToChange.sortingOrder = -1;
        }
    }
}
