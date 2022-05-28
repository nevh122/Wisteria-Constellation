using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPCInteractEvent : MonoBehaviour
{
    public UnityEvent whenInteracted;
    DialogueManager manager;
    public bool isInside = false;

    void Start()
    {
        manager = FindObjectOfType<DialogueManager>();
    }

    //if the player press interact button and in range does the following
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInside)
        {
            if (manager.isDone)
            {
                whenInteracted.Invoke();
            }
            else
            {
                manager.DisplayNextDialogue();
            }
        }
    }

    //Checks if the player is within interaction range
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInside = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInside = false;
            manager.EndDialogue();
        }
    }
}
