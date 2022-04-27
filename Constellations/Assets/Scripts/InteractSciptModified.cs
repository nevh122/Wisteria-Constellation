using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractSciptModified : MonoBehaviour
{
    bool inRange;
    public UnityEvent whenInteracted;
    public GameObject player;
    int FirstEnc = 0;
    void Update()
    {
        if (inRange) 
        { 
            switch (FirstEnc)
            {
                case 0:
                    whenInteracted.Invoke();
                    player.GetComponent<PlayerController>().enabled = false;
                    break;
                default:
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        whenInteracted.Invoke();
                        player.GetComponent<PlayerController>().enabled = false;
                    }
                    break;
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
            FirstEnc++;
        }
    }
}
