using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class Enemy : Entity
{
    [Header("Follow Baby")]
    [SerializeField] private Transform baby;
    [SerializeField] private float distanceToBaby = 3f;
    private bool playerDetected;
    [Header("Movement details")]
    [SerializeField] protected float moveSpeed = 8f;
    private void Awake()
    {
        attackPoint = transform.Find("AttackPoint");
        //base.Start();
    }
    protected override void Update()
    {
        base.Update();
        HandleAttack();
    }
    protected override void HandleMovement()
    {
        
        if (canMove && Math.Abs(transform.position.x - baby.position.x) > distanceToBaby)
        {
            rb.linearVelocity = new Vector2(facingDir * moveSpeed, rb.linearVelocityY);
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocityY);
        }
    }
    protected override void HandleFlip()
    {
        if (baby.transform.position.x > transform.position.x && !facingRight)
        {
            Flip();
        }
        else if (baby.transform.position.x < transform.position.x && facingRight)
        {
            Flip();
        }
    }
    protected override void HandleAttack()
    {
        if (playerDetected)
        {
            anim.SetTrigger("attack");
        }
    }
    protected override void HandleCollision()
    {
        base.HandleCollision();
        //if(attackPoint != null)
        playerDetected = Physics2D.OverlapCircle(attackPoint.position, attackRadius, whatIsTarget);
        //Console.WriteLine("Player Detected: " + playerDetected);
        //Console.WriteLine("Attack Point Position: " + attackPoint.position);
    }
    protected override void Die()
    {
        base.Die();
        //UI.instance.AddKillCount();
    }
}
