using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private Animator animator;
    public Animator disclaimer;
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    public void PlayButton()
    {
        animator.SetBool("isPlay", true);
        disclaimer.SetBool("isPlay", true);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void returnButton()
    {
        animator.SetBool("isPlay", false);
        disclaimer.SetBool("isPlay", false);
    }
    public void ContinueButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
