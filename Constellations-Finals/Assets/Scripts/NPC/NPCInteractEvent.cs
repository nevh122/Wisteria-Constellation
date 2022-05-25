using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPCInteractEvent : MonoBehaviour
{
    public UnityEvent whenInteracted;
    bool hasInteracted;
    DialogueManager manager;

    void Start()
    {
        manager = FindObjectOfType<DialogueManager>();
    }

    void Update()
    {
        if (hasInteracted)
        {
            if(manager.isDone == false)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    whenInteracted.Invoke();
                }
            }
        }

    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hasInteracted = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hasInteracted = false;
        }
    }
}
