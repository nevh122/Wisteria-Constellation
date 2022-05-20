using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float chaseSpeed = 10f;

    Vector3 offset;
    Vector3 playerPos;
    void Start()
    {
        offset = transform.position - player.position;
    }

    void Update()
    {
        playerPos = player.position + offset;
        transform.position = Vector3.LerpUnclamped(transform.position, playerPos, chaseSpeed * Time.deltaTime);
    }
}
