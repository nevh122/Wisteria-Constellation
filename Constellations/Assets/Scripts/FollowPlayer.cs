using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float speed;
    public Transform player;

    public Vector3 offset;
    Vector3 playerPos;
    void Update()
    {
        playerPos = player.position + offset;
        transform.position = Vector3.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
    }
}
