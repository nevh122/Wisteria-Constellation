using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class OpeningScneTransition : MonoBehaviour
{
    public Animator TransitionEffect;
    public VideoPlayer Cutscene;
    public int buildIndex;

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + buildIndex);
    }
}
