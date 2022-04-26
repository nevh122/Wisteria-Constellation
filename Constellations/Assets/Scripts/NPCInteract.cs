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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plaayer"))
        {
            inRange = true;
            Debug.Log("Player inside");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plaayer"))
        {
            inRange = false;
            Debug.Log("Player outside");
        }
    }
}
