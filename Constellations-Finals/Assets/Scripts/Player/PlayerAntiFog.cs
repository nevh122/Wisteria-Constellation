using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;


//Moves the anti fog arae to player's position
public class PlayerAntiFog : MonoBehaviour
{
    public VisualEffect Fog;

    public void Update()
    {
        Fog.SetVector3("PlayerPosition", gameObject.transform.position);
    }
}
