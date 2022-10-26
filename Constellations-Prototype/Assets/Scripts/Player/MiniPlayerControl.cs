using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//handles controls for the sanity event player
public class MiniPlayerControl : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    void Update()
    {
        MovePlayer();
    }

    public void MovePlayer()
    {
        Vector2 direction = Vector2.zero;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direction.x = -1;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            direction.x = 1;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            direction.y = 1;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            direction.y = -1;
        }
        direction.Normalize();
        GetComponent<Rigidbody2D>().velocity = moveSpeed * direction;
    }
}
