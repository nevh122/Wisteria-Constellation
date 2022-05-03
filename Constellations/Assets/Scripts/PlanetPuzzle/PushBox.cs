using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBox : MonoBehaviour
{
    void OnCollisionExit2D(Collision2D colExt)
    {
        if (colExt.gameObject.tag == "box")
            colExt.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }
}
