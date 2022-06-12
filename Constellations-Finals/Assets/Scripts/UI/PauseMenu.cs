using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuUI;
    public GameObject player;
    bool isOpen = false;
    public int buildIndex;

    //if player press main menu button
    private void Update()
    {
        if(isOpen == false)
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
    }

    //to be called by pause menu buttons
    public void OpenPauseMenu()
    {
        isOpen = true;
        Time.timeScale = 0;
        PauseMenuUI.SetActive(true);
        player.GetComponent<PlayerMovement>().enabled = false;
    }
    public void ClosePauseMenu()
    {
        isOpen = false;
        Time.timeScale = 1;
        PauseMenuUI.SetActive(false);
        player.GetComponent<PlayerMovement>().enabled = true;
    }
    public void QuitToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + buildIndex);
    }
}
