using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConnectingScenes : MonoBehaviour
{
    public Animator RetryAnim;
    public Animator MainMenuAnim;

    public void Retry()
    {
        RetryAnim.SetTrigger("Transition");
    }
    public void ReturnToMenu()
    {
        MainMenuAnim.SetTrigger("Transition");
    }
}
