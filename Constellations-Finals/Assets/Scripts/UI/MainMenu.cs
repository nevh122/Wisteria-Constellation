using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Animator Transition;
    public Animator MenuButtons;
    public Animator HowToPlay;

    //to be called by buttons in main menu screen
    private void Start()
    {
        MenuButtons.SetBool("IsOpen", true);
        HowToPlay.SetBool("IsOpen", false);
    }
    public void StartGame()
    {
        Transition.SetTrigger("Transition");
    }
    public void OpenHowToPlay()
    {
        MenuButtons.SetBool("IsOpen", false);
        HowToPlay.SetBool("IsOpen", true);
    }
    public void CloseHowToPlay()
    {
        MenuButtons.SetBool("IsOpen", true);
        HowToPlay.SetBool("IsOpen", false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
