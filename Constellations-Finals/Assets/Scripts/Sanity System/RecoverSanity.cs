using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class RecoverSanity : MonoBehaviour
{
    public PlayerController playerController;
    public PostProcessVolume sanityEffect;
    Vignette anxietyVignette;

    private void Start()
    {
        sanityEffect.profile.TryGetSettings(out anxietyVignette);
    }
    private void Update()
    {
        //locks sanity numbers to not exceed a certain number
        anxietyVignette.intensity.value = Mathf.Clamp(anxietyVignette.intensity.value, 0f, 1f);
        playerController.anxietyLevel = anxietyVignette.intensity.value;
    }

    //increases anxiety when staying at the zones
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (playerController.inConvo == false)
            {
                anxietyVignette.intensity.value = anxietyVignette.intensity.value - Time.deltaTime * 0.02f;
            }
        }
    }
}
