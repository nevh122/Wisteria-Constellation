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

    public float playerlives = 3f;
    public bool playerIsDead = false;
    public Animator playerHealthIndicator;

    public PlayerMovement playerMovement;

    public bool Sunkey;
    public bool StarKey;
    public bool WithJanus;
    public bool MoonKey;
    public bool CloverLeaf;

    public TextMeshProUGUI inventoryText;
    public Animator DeathTransition;
    public Image transitionImage;

    public ChoicesDialogue choicesDialogue;
    public DialogueManager dialogueManager;
    public CodePuzzleInput puzzleInput;

    void Update()
    {
        anxietyLevel = Mathf.Clamp(anxietyLevel, 0f, 1f);
        CheckPlayerDead();
        ControlChecker();
        PlayerLives();
    }
    //called by other scripts when player has died
    public void CheckPlayerDead()
    {
        if(playerlives == 0 || playerIsDead == true)
        {
            StartCoroutine(PlayerisDeadGotoNextScene());
        }
        
    }
    public void ControlChecker()
    {
        if (choicesDialogue.isActive || dialogueManager.isActive || puzzleInput.isOpen)
        {
            playerMovement.enabled = false;
            inConvo = true;
        }
        else if (choicesDialogue.isActive == false || dialogueManager.isActive == false || puzzleInput.isOpen == false)
        {
            playerMovement.enabled = true;
            inConvo = false;
        }
    }
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
    IEnumerator PlayerisDeadGotoNextScene()
    {
        DeathTransition.SetBool("Transition", true);
        playerMovement.enabled = false;
        this.enabled = false;
        yield return new WaitUntil(() => transitionImage.color.a == 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
