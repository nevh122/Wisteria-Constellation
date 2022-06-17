using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSlots : MonoBehaviour
{
    public GameObject planetForThisSlot;
    public bool isRight = false;

    //locks planet in slot if it is the right position
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == planetForThisSlot)
        {
            isRight = true;
            planetForThisSlot.GetComponent<CircleCollider2D>().enabled = false;
            planetForThisSlot.GetComponent<PushBox>().enabled = false;
            planetForThisSlot.transform.position = gameObject.transform.position;
        }
    }
}
