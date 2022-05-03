using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectwhenRight : MonoBehaviour
{
    public GameObject planet;
    public bool isRight = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == planet)
        {
            isRight = true;
            planet.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            planet.transform.position = gameObject.transform.position;
        }
    }
}
