using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    public float Speed;
    public float jumpForce;

    //-------------------------------//
    public bool betterJump = false;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1f;
    //------------------------------//


    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (/*Input.GetKeyDown("w") &&*/ CheckGroundFrog.canJump)
        {
            Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, jumpForce);
        }

        if (CheckGroundFrog.canJump == false)
        {
            Animator.SetBool("Jumping", true);
            Animator.SetBool("Walk", false);
        }
        if (CheckGroundFrog.canJump == true)
        {
            Animator.SetBool("Jumping", false);
            Animator.SetBool("Falling", false);
        }
        if (Rigidbody2D.velocity.y < 0)
        {
            Animator.SetBool("Falling", true);
        }
        else if (Rigidbody2D.velocity.y > 0)
        {
            Animator.SetBool("Falling", false);
        }        
    }

    private void FixedUpdate()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        Animator.SetBool("Walk", Horizontal != 0.0f);

        if (Horizontal < 0.0f)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }

        else if (Horizontal > 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        if (betterJump)
        {
            if (Rigidbody2D.velocity.y < 0 && Input.GetKey("w"))
            {
                Rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }
            if (Rigidbody2D.velocity.y > 0 && !Input.GetKey("w"))
            {
                Rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }
        }

        Rigidbody2D.velocity = new Vector2(Horizontal * Speed * Time.deltaTime, Rigidbody2D.velocity.y);
    }
}