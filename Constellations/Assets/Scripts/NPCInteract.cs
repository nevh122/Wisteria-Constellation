using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPCInteract : MonoBehaviour
{
    public bool inRange;
    public UnityEvent whenInteracted;
    public GameObject player;
    public DialogueManager manager;
    bool hasInteracted;
    public GameObject exclamationPoint;

    private void Start()
    {
        manager = FindObjectOfType<DialogueManager>();
    }
    void Update()
    {
        if (inRange && hasInteracted == false)
        {
            if (manager.IsDone == true)
            {
                if (Input.GetKeyDown(KeyCode.X))
                {
                    hasInteracted = true;
                    whenInteracted.Invoke();
                }
            }
        }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = true;
            exclamationPoint.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = false;
            hasInteracted = false;
            exclamationPoint.SetActive(false);
        }
    }
}
