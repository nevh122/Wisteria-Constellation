using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Canvas UICanvas;
    public Camera MainCam;
    public Camera EncounterCam;

    public EncounterSystem encounterSystem;
    public GameObject PauseMenuUI;
    public GameObject player;
    public bool isOpen = false;
    public int buildIndex;
    CodePuzzleInput puzzleInput;

    public AudioSource openPauseMenu;
    public AudioSource closePauseMenu;
    private void Start()
    {
        puzzleInput = FindObjectOfType<CodePuzzleInput>();
    }

    //if player press main menu button
    private void Update()
    {
        if(isOpen == false && puzzleInput.isOpen == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Tab))
            {
                OpenPauseMenu();
            }
        }
        else if (isOpen)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Tab))
            {
                ClosePauseMenu();
            }
        }
        
        if (encounterSystem.inEncounter == true)
        {
            UICanvas.worldCamera = EncounterCam;
        }
        else if (encounterSystem.inEncounter == false)
        {
            UICanvas.worldCamera = MainCam;
        }
    }

    //to be called by pause menu buttons
    public void OpenPauseMenu()
    {
        isOpen = true;
        Time.timeScale = 0;
        PauseMenuUI.SetActive(true);
        player.GetComponent<PlayerMovement>().enabled = false;
        openPauseMenu.Play();
    }
    public void ClosePauseMenu()
    {
        isOpen = false;
        Time.timeScale = 1;
        PauseMenuUI.SetActive(false);
        player.GetComponent<PlayerMovement>().enabled = true;
        closePauseMenu.Play();
    }
    public void QuitToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + buildIndex);
    }
}
