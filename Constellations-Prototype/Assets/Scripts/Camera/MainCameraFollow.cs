using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraFollow : MonoBehaviour
{
    public Transform player;
    public float chaseSpeed = 10f;
    //zoom to player or distance of camera from the player on the z axis
    public float distanceToPlayer;

    Vector3 offset;
    Vector3 playerPos;

    //Centers the camera at the start to player, then calculates the offset
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
