using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TeleportInteract : MonoBehaviour
{
    bool inRange;
    public UnityEvent whenInteracted;
    public GameObject player;
    void Update()
    {
        if (inRange)
        {

            whenInteracted.Invoke();
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
