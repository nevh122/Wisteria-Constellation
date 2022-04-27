using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractedObjects : MonoBehaviour
{
    public GameObject player;
    public void ExitButton()
    {
        player.GetComponent<PlayerController>().enabled = true;
    }

}
