using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float chaseSpeed = 10f;
    //zoom on the player based on the z axis
    public float distanceToPlayer;

    Vector3 offset;
    Vector3 playerPos;

    //Places camera away from player
    void Start()
    {
        transform.position = new Vector3(player.position.x, player.position.y, distanceToPlayer);
        offset = transform.position - player.position;
    }

    //Adds offset and applies a following motion to the player
    void Update()
    {
        playerPos = player.position + offset;
        transform.position = Vector3.LerpUnclamped(transform.position, playerPos, chaseSpeed * Time.deltaTime);
    }
}
