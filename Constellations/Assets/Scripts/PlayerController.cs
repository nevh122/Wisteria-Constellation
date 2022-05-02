using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float _mSpeed;
    Animator playerAnimator;

    public int StarKey;
    public int CloverPendant = 1;
    public int CloverLeaf;
    public int MoonKey;
    public int SunKey;
    public int withJanus;
    
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }
    void Update()
    {
        ControlPlayer();
    }
    void ControlPlayer()
    {
        Vector2 direction = Vector2.zero;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direction.x = -1;
            playerAnimator.SetInteger("Direction", 3);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            direction.x = 1;
            playerAnimator.SetInteger("Direction", 2);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            direction.y = 1;
            playerAnimator.SetInteger("Direction", 1);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            direction.y = -1;
            playerAnimator.SetInteger("Direction", 0);
        }

        direction.Normalize();
        playerAnimator.SetBool("IsMoving", direction.magnitude > 0);

        GetComponent<Rigidbody2D>().velocity = _mSpeed * direction;

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
