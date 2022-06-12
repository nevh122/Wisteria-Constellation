using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.Events;

public class OpeningScneTransition : MonoBehaviour
{
    public Animator TransitionEffect;
    public VideoPlayer Cutscene;
    public int buildIndex;
    public UnityEvent whenInvoked;

    //checks if opening video is done to shift to next scene
    private void Update()
    {
        Cutscene.loopPointReached += CheckOver;
    }
    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        TransitionEffect.SetTrigger("Transition");
    }

    public void ChangeScene()
    {
        whenInvoked.Invoke();
    }

    public void ChangeToNewIndex()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + buildIndex);
    }
}
