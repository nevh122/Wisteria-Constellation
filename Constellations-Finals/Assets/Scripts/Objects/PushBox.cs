using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBox : MonoBehaviour
{
    Rigidbody2D boxBody;
    public Vector3 originalPos;

    private void Start()
    {
        boxBody = GetComponent<Rigidbody2D>();
    }

    //moves object when player is touching it
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            boxBody.constraints = RigidbodyConstraints2D.None;
        }
    }

    //makes objects stops moving when player is not touching
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            boxBody.constraints = RigidbodyConstraints2D.FreezeAll;
            boxBody.velocity = Vector3.zero;
        }
    }

    //to be called, resets the position of the objects
    public void ReturntoOriginalPosition()
    {
        transform.position = originalPos;
    }
}
