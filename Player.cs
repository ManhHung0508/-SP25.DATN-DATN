using System;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jump;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    private Animator animator;
    private bool isGrounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       move();
       Jump();
       UpdateAnimation();
    }
    private void move(){
       float moveInput = Input.GetAxis("Horizontal");
       rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
       if(moveInput>0) transform.localScale = new Vector3(1, 1 ,1);
       else if(moveInput<0) transform.localScale = new Vector3 (-1, 1 ,1);
    }
    private void Jump(){

        if(Input.GetButtonDown("Jump") && isGrounded){
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump);
        }
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void UpdateAnimation(){
        bool isRunning = Mathf.Abs(rb.linearVelocity.x)> 0;
        bool isJump = !isGrounded;
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isJump", isJump);
    }
}
