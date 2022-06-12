using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Vector3 offset;
    [SerializeField] Transform Player;
    Vector3 JanusPos;

    // object follows player with fixed offset
    void Update()
    {
        JanusPos = Player.position + offset;
        transform.position = Vector3.LerpUnclamped(transform.position, JanusPos, moveSpeed * Time.deltaTime);
    }
}
