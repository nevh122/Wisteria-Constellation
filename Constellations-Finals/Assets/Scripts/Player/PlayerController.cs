using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Calls other scripts connected to the player, used to avoid script contradictions when adding features
public class PlayerController : MonoBehaviour
{
    PlayerMovement playerMovement;
    public bool Sunkey;
    public bool StarKey;
    public bool WithJanus;
    public bool MoonKey;
    public bool CloverLeaf;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    void Update()
    {
        playerMovement.Move();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
