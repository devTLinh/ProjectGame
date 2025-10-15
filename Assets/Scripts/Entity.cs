using System;
using System.Collections;
using UnityEngine;

public class Entity : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected Animator anim;

    protected float facingDir = 1f;
    protected bool facingRight = true;
    protected bool canMove = true;

    [Header("Health details")]
    [SerializeField] protected int maxHealth = 100;
    [SerializeField] protected int currentHealth;

    [Header("Attack details")]
    private bool canAttack = true;
    [SerializeField] public int attackDamage = 0;
    [SerializeField] protected float attackRadius;
    [SerializeField] protected Transform attackPoint;
    [SerializeField] protected LayerMask whatIsTarget;

    [Header("Collision details")]
    [SerializeField] private float groundCheckDistance;
    protected bool isGrounded;


    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        currentHealth = maxHealth;
    }
    protected virtual void Update()
    {
        HandleCollision();
        HandleMovement();
        HandleAnimation();
        HandleFlip();
    }
    public void DamageTargets(int attackDamage)
    {
        Collider2D[] enemyColliders = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, whatIsTarget);
        foreach (Collider2D item in enemyColliders)
        {
            Entity entityTarget = item.GetComponent<Entity>();
            entityTarget.TakeDamage(attackDamage);
        }
    }

    protected virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("isDamaged");
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        anim.SetTrigger("isDead");
    }
    public virtual void DestroyEntity()
    {
        gameObject.SetActive(false);
    }
    public virtual void EnableMovement(bool enable)
    {
        canMove = enable;
    }
    public virtual void EnableAttack(bool enable)
    {
        canAttack = enable;
    }
    protected virtual void HandleCollision()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, LayerMask.GetMask("Ground"));
    }

    protected virtual void HandleFlip()
    {
        if (rb.linearVelocityX > 0 && !facingRight)
        {
            Flip();
        }
        else if (rb.linearVelocityX < 0 && facingRight)
        {
            Flip();
        }
    }

    protected virtual void HandleAnimation()
    {
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("yVelocity", rb.linearVelocityY);
        anim.SetFloat("xVelocity", rb.linearVelocityX);
    }

    protected virtual void HandleMovement()
    {
        
    }
    protected virtual void HandleAttack()
    {
        anim.SetTrigger("attack");
    }
    public void Flip()
    {
        transform.Rotate(0, 180, 0);
        facingRight = !facingRight;
        facingDir *= -1;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, -groundCheckDistance));
        if (attackPoint != null)
            Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}
