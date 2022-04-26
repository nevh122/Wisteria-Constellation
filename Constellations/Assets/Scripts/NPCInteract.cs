using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPCInteract : MonoBehaviour
{
    public bool inRange;
    public KeyCode interact;
    public UnityEvent whenInteracted;

    void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(interact))
            {
                whenInteracted.Invoke();
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
