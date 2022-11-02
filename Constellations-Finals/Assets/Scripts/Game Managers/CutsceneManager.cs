using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


//handles what will happen once the cutscene is finished
public class CutsceneManager : MonoBehaviour
{
    public VideoPlayer cutscene;
    public Image transitionImage;
    public Animator transitionAnim;


    void Start()
    {
        cutscene.loopPointReached += NextScene;   
    }

    void NextScene(VideoPlayer vp)
    {
        StartCoroutine(Transition());
    }

    IEnumerator Transition()
    {
        transitionAnim.SetBool("Transition", true);
        yield return new WaitUntil(() => transitionImage.color.a == 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
