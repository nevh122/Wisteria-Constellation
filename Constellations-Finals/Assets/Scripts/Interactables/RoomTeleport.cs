using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTeleport : MonoBehaviour
{
    [SerializeField] Vector2 teleportLocation;
    public GameObject Player;
    bool isInside;

    //checks if player is stepping on teleporter
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInside = true;
            StartTeleport();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInside = false;
        }
    }

    //teleports player to location
    public void StartTeleport()
    {
        if(isInside)
        Player.transform.position = teleportLocation;
    }
}
