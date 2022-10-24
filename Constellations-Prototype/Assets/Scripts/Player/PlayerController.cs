using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    public Animator playerAnim;

    void Update()
    {
        MovePlayer();
    }
    
    //Handles Player movement using WASD or the Arrow Keys with animations
    public void MovePlayer()
    {
        Vector2 direction = Vector2.zero;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direction.x = -1;
            playerAnim.SetInteger("Direction", 3);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            direction.x = 1;
            playerAnim.SetInteger("Direction", 4);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            direction.y = 1;
            playerAnim.SetInteger("Direction", 2);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            direction.y = -1;
            playerAnim.SetInteger("Direction", 1);

        }

        direction.Normalize();
        playerAnim.SetBool("IsMoving", direction.magnitude > 0);
        GetComponent<Rigidbody2D>().velocity = moveSpeed * direction;
    }
}
