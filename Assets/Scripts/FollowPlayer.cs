using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private float moveSpeed;
    
    private Rigidbody2D cameraBody;

    
    private Player player;

    private bool isRunning;

    private void Start()
    {
        cameraBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (player == null)
        {
            player = FindObjectOfType<Player>();
        }

        moveSpeed = player.speed;

        if (Input.anyKeyDown)
            isRunning = true;
    }

    private void FixedUpdate()
    {
        if (isRunning)
            cameraBody.velocity = new Vector2(moveSpeed, cameraBody.velocity.y);
    }
}
