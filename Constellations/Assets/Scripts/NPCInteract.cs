using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPCInteract : MonoBehaviour
{
    bool inRange;
    public UnityEvent whenInteracted;
    public GameObject player;
    void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                whenInteracted.Invoke();
                player.GetComponent<PlayerController>().enabled = false;
            }
        }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}
