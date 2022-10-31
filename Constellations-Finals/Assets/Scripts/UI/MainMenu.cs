using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Animator transitionAnim;
    public Image transitionImage;
    public GameObject MenuButtons;
    public GameObject HowToPlay;

    //to be called by buttons in main menu screen
    private void Start()
    {
        MenuButtons.SetActive(true);
        HowToPlay.SetActive(false);
    }

    public void StartGame()
    {
        StartCoroutine(StartFunction());
    }

    public void OpenHowToPlay()
    {
        MenuButtons.SetActive(false);
        HowToPlay.SetActive(true);
    }

    public void CloseHowToPlay()
    {
        MenuButtons.SetActive(true);
        HowToPlay.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator StartFunction()
    {
        transitionAnim.SetBool("Transition", true);
        yield return new WaitUntil(() => transitionImage.color.a == 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
