using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityAccumulation : MonoBehaviour
{
    public float SanityMeter = 50;
    public Image SanityScreen;

    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
           SanityMeter = SanityMeter - Time.deltaTime;
        }
    }
    void Update()
    {
        if (SanityMeter >= 50)
        {
        }
    }
}
