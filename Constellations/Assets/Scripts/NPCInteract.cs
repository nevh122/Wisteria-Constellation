using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPCInteract : MonoBehaviour
{
    bool inRange;
    public UnityEvent whenInteracted;
    public GameObject player;
    public DialogueManager manager;

    private void Start()
    {
        manager = FindObjectOfType<DialogueManager>();
    }
    void Update()
    {
       if(inRange)
        {
            if (manager.IsDone)
            {
                if (Input.GetKeyDown(KeyCode.X))
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
