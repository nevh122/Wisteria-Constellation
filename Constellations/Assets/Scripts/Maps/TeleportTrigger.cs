using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTrigger : MonoBehaviour
{
    public Positions teleportPos;

    public void TriggerTeleport()
    {
        FindObjectOfType<TeleportManager>().StartTeleport(teleportPos);
    }
}
