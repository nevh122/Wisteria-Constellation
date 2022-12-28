using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    public Animator playerAnim;

    public AudioSource runLeft;
    public AudioSource runRight;

    public void Update()
    {
        Move();
    }

    //Handles movement and animation for player
    public void Move()
    {
        Vector2 direction = Vector2.zero;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direction.x = -1;
            playerAnim.SetInteger("Direction", 0);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            direction.x = 1;
            playerAnim.SetInteger("Direction", 1);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            direction.y = 1;
            playerAnim.SetInteger("Direction", 2);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            direction.y = -1;
            playerAnim.SetInteger("Direction", 3);
        }

        direction.Normalize();
        playerAnim.SetBool("IsMoving", direction.magnitude > 0);

        GetComponent<Rigidbody2D>().velocity = moveSpeed * direction;
    }

    //Plays audio when player moves
    public void RunLeft()
    {
        runLeft.Play();
    }
    public void RunRight()
    {
        runRight.Play();
    }
}
