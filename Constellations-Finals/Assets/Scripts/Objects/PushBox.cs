using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBox : MonoBehaviour
{
    Rigidbody2D boxBody;

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
}
