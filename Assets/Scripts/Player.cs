using System;
using UnityEngine;

public class Player : Entity
{
    [Header("Movement details")]
    [SerializeField] protected float moveSpeed = 8f;
    [SerializeField] private float jumpForce = 8f;
    private float xInput;
    bool canJump = true;
    private void Awake()
    {
        base.Start();
        attackDamage = 35;
    }
    protected override void Update()
    {
        base.Update();
        HandleInput();
    }
    protected override void HandleMovement()
    {
        if (canMove)
            rb.linearVelocity = new Vector2(xInput * moveSpeed, rb.linearVelocityY);
        else
            rb.linearVelocity = new Vector2(0, rb.linearVelocityY);
    }
    private void HandleInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TryToJump();
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            HandleAttack();
        }
    }
    private void TryToJump()
    {
        if (isGrounded && canJump)
            rb.linearVelocityY = jumpForce;
    }
    public override void EnableMovement(bool enable)
    {
        canMove = enable;
        canJump = enable;
    }
    protected override void Die()
    {
        base.Die();
        EnableMovement(false);
        UI.instance.EnableGameOverUI();
        
    }
}
        
