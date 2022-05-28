using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float chaseSpeed = 10f;

    Vector3 offset;
    Vector3 playerPos;

    //Places camera away from player
    void Start()
    {
        offset = transform.position - player.position;
    }

    //Adds offset and applies a following motion to the player
    void Update()
    {
        playerPos = player.position + offset;
        transform.position = Vector3.LerpUnclamped(transform.position, playerPos, chaseSpeed * Time.deltaTime);
    }
}
