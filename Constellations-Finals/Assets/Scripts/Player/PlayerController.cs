using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


//Calls other scripts connected to the player, used to avoid script contradictions when adding features
public class PlayerController : MonoBehaviour
{
    PlayerMovement playerMovement;
    public bool Sunkey;
    public bool StarKey;
    public bool WithJanus;
    public bool MoonKey;
    public bool CloverLeaf;
    public TextMeshProUGUI inventoryText;
    public Animator DeathTransition;
    TreeNymphChoicesDialogue treeNymph;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    void Update()
    {
        playerMovement.Move();
    }
    //called by other scripts when player has died
    public void CheckPlayerDead()
    {
        DeathTransition.SetTrigger("Transition");
    }
}
