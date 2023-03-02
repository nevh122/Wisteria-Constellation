using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//Calls other scripts connected to the player, used to avoid script contradictions when adding features
public class PlayerController : MonoBehaviour
{
    public float anxietyLevel;
    public bool inConvo = false;
    public bool teleporting = false;
    public GameObject anxietyHeartbeats;
    public EncounterSystem encounterSystem;

    public float playerlives = 3f;
    public bool playerIsDead = false;
    public Animator playerHealthIndicator;

    public PlayerMovement playerMovement;
    public Rigidbody2D playerRBody;

    public bool Labyrinthkey;
    public bool MapleKey;
    public bool WithJanus;
    public bool GalaxyKey;
    public bool CloverLeaf;
    public bool LakeKey;
    public bool Boots;

    public TextMeshProUGUI inventoryText;
    public Animator DeathTransition;
    public Image transitionImage;

    public ChoicesDialogue choicesDialogue;
    public DialogueManager dialogueManager;
    public CodePuzzleInput puzzleInput;

    public AudioSource runLeft;
    public AudioSource runRight;
    void Update()
    {
        anxietyLevel = Mathf.Clamp(anxietyLevel, 0f, 1f);
        CheckPlayerDead();
        ControlChecker();
        PlayerLives();
        AnxietyIndicator();
        RunWithBoots();
    }
    //called by other scripts when player has died
    public void CheckPlayerDead()
    {
        if(playerlives == 0 || playerIsDead)
        {
            StartCoroutine(PlayerisDeadGotoNextScene());
        }
        
    }
    //checks if player should have control on specific scenarios
    public void ControlChecker()
    {
        if (choicesDialogue.isActive || dialogueManager.isActive || puzzleInput.isOpen || teleporting || encounterSystem.inEncounter)
        {
            playerRBody.constraints = RigidbodyConstraints2D.FreezeAll;
            playerMovement.enabled = false;
            inConvo = true;
        }
        else if (!choicesDialogue.isActive || !dialogueManager.isActive || !puzzleInput.isOpen || !teleporting || !encounterSystem.inEncounter)
        {
            playerRBody.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
            playerMovement.enabled = true;
            inConvo = false;
        }
    }
    //changes the screen color when player health is low
    public void PlayerLives()
    {
        switch (playerlives)
        {
            case 3:
                playerHealthIndicator.SetInteger("HPPhase", 3);
                break;
            case 2:
                playerHealthIndicator.SetInteger("HPPhase", 2);
                break;
            case 1:
                playerHealthIndicator.SetInteger("HPPhase", 1);
                break;
            case 0:
                playerIsDead = true;
                break;
        }
    }
    //starts heartbeats sounds when player reach a certain treshhold
    public void AnxietyIndicator()
    {
        if(anxietyLevel >= 0.5f)
        {
            anxietyHeartbeats.SetActive(true);
        }
        else
        {
            anxietyHeartbeats.SetActive(false);
        }
    }
    //what happens when the player has 0 hp left
    IEnumerator PlayerisDeadGotoNextScene()
    {
        DeathTransition.SetBool("Transition", true);
        playerMovement.enabled = false;
        this.enabled = false;
        yield return new WaitUntil(() => transitionImage.color.a == 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Plays audio when player moves
    public void RunLeft()
    {
        if (choicesDialogue.isActive || dialogueManager.isActive || puzzleInput.isOpen || teleporting || encounterSystem.inEncounter)
        {
            runLeft.Stop();
        }
        else
        {
            runLeft.Play();
        }
    }
    public void RunRight()
    {
        if (choicesDialogue.isActive || dialogueManager.isActive || puzzleInput.isOpen || teleporting || encounterSystem.inEncounter)
        {
            runRight.Stop();
        }
        else
        {
            runRight.Play();
        }
            
    }

    //handles boots movement
    public void RunWithBoots()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && Boots == true)
        {
            playerMovement.moveSpeed = playerMovement.moveSpeed + 4f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) && Boots == true)
        {
            playerMovement.moveSpeed = playerMovement.moveSpeed - 4f;
        }
    }
}
