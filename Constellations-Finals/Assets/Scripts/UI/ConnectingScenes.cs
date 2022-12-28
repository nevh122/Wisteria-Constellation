using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//used by ending and victory screens buttons
public class ConnectingScenes : MonoBehaviour
{
    public Animator transitionAnim;
    public Image transitionImage;
    public AudioSource buttonPressed;
    public int retryLoad;
    public int menuLoad;
    int sceneToLoad;

    public void Retry()
    {
        sceneToLoad = retryLoad;
        buttonPressed.Play();
        StartCoroutine(Transition());
    }
    public void ReturnToMenu()
    {
        sceneToLoad = menuLoad;
        buttonPressed.Play();
        StartCoroutine(Transition());
    }

    IEnumerator Transition()
    {
        transitionAnim.SetBool("Transition", true);
        yield return new WaitUntil(() => transitionImage.color.a == 1);
        SceneManager.LoadScene(sceneToLoad);
    }
}
