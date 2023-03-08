using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private ParticleSystem dust;

    public float speed;
    private float originSpeed;
    public float jumpForce;
    private bool canDoubleJump;

    public float speedMultiplier;
    private int increaseSpeedMileStone;
    private int mileStone;

    private bool isRunning;
    public bool IsRunning 
    { 
        get 
        {
            return isRunning;
        } 
    }

    private bool isJump;
    private bool enableJump;

    private Rigidbody2D playerBody;
    private Animator playerAni;
    private CapsuleCollider2D coll;
    
    [SerializeField]
    private LayerMask groundLayer;

    private void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerAni = GetComponent<Animator>();
        coll = GetComponent<CapsuleCollider2D>();

        increaseSpeedMileStone = 35;
        mileStone = increaseSpeedMileStone;

        originSpeed = speed;
       
    }

    private void Update()
    {


        if (transform.position.x > mileStone)
        {
            mileStone += increaseSpeedMileStone;
            speed = speed * speedMultiplier;
        }

        // Get the game start
        if (Input.anyKeyDown)
            isRunning = true;
        

        // Make Dino jump
        if (Input.GetKeyDown(KeyCode.Space) && enableJump)
        {
            isJump = true;
            playerAni.SetBool("Jump", true);
        }
    }

    private void FixedUpdate()
    {
        if (dust == null)
        {
            dust = FindObjectOfType<ParticleSystem>();
        }
        Running();
        Jump();
    }

    private void Running()
    {
        if (isRunning)
        {
            if (isGrounded())
                PlayDust();
            enableJump = true;
            playerAni.SetTrigger("Run");
            playerBody.velocity = new Vector2(speed, playerBody.velocity.y);
        }
    }

    private void Jump()
    {
        if (isJump && isGrounded())
        {
            
            isJump = false;
            playerBody.velocity = new Vector2(playerBody.velocity.x, 0);
            playerBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            playerAni.SetBool("Jump", false);
            canDoubleJump = true;
        }
        else if (canDoubleJump && isJump)
        {
            isJump = false;
            canDoubleJump = false;
            playerBody.velocity = new Vector2(playerBody.velocity.x, 0);
            playerBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            playerAni.SetBool("Jump", false);
        }
    }
    
    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, new Vector2(0.3f, 0.1f), 0f, Vector2.down, (coll.bounds.size.y / 2) + .1f, groundLayer);
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Danger")
        {
            GameManager.instance.RestartGame();
            speed = originSpeed;
            mileStone = increaseSpeedMileStone;
        }
    }

    public void ChangeSpeed()
    {
        speed = originSpeed;
        mileStone = increaseSpeedMileStone;
    }

    private void PlayDust()
    {
        dust.Play();
    }

}
