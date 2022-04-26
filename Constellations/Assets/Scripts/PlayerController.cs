using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _mSpeed;
    Animator playerAnimator;

    
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector2 direction = Vector2.zero;

        if (Input.GetKey(KeyCode.A))
        {
            direction.x = -1;
            playerAnimator.SetInteger("Direction", 3);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direction.x = 1;
            playerAnimator.SetInteger("Direction", 2);
        }

        if (Input.GetKey(KeyCode.W))
        {
            direction.y = 1;
            playerAnimator.SetInteger("Direction", 1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direction.y = -1;
            playerAnimator.SetInteger("Direction", 0);
        }

        direction.Normalize();
        playerAnimator.SetBool("IsMoving", direction.magnitude > 0);

        GetComponent<Rigidbody2D>().velocity = _mSpeed * direction;
    }
}