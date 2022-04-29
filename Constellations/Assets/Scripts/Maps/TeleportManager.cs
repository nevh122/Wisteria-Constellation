using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportManager : MonoBehaviour
{
    public GameObject player;

    public void StartTeleport(Positions position)
    {
        player.transform.position = position.endPos;
    }
}
