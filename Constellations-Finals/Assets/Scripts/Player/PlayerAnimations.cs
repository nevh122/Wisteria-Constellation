using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    PlayerMovement playerMove;
    Animator playerAnim;

    private void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerMove = GetComponent<PlayerMovement>();
    }

    public void Animations()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            playerAnim.SetInteger("Direction", 1);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            playerAnim.SetInteger("Direction", 2);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            playerAnim.SetInteger("Direction", 3);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            playerAnim.SetInteger("Direction", 4);
        }

        //playerAnim.SetBool("IsMoving", playerMove.direction.magnitude > 0);
    }
}
