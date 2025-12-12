using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Baby : Entity
{
    [SerializeField] private Transform player;
    private SpriteRenderer sr;
    private float moveSpeed = 8f;
    private float distanceToPlayer = 3f;
    [SerializeField]private Material damageMaterial;
    private Material original;
    private Coroutine DamageFeedback;
    private float damageFlashDuration = .5f;
    [SerializeField] private float wallCheckDistance;
    protected bool isTouchingWall;
    [SerializeField] private float jumpForce;
    private void Awake()
    {
        base.Start();
        sr = GetComponentInChildren<SpriteRenderer>();
        original = sr.material;
    }
    protected override void Update()
    {
        base.Update();
        if(Physics2D.Raycast(transform.position, Vector2.right * facingDir, wallCheckDistance, LayerMask.GetMask("NextLevel")))
        {
            int index = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(index);
        }
    }
    protected override void HandleMovement()
    {
        if (Mathf.Abs(player.transform.position.x - transform.position.x) > distanceToPlayer)
        {
            rb.linearVelocity = new Vector2(facingDir * moveSpeed, rb.linearVelocityY);
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocityY);
        }
        if (isTouchingWall && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
    protected override void HandleCollision()
    {
        base.HandleCollision();
        isTouchingWall = Physics2D.Raycast(transform.position, Vector2.right * facingDir, wallCheckDistance, LayerMask.GetMask("Ground"));
    }
    protected override void HandleFlip()
    {
        if (player.transform.position.x > transform.position.x && !facingRight)
        {
            Flip();
        }
        else if (player.transform.position.x < transform.position.x && facingRight)
        {
            Flip();
        }
    }
    private IEnumerator damageFeedback()
    {
        sr.material = damageMaterial;
        yield return new WaitForSeconds(damageFlashDuration);
        sr.material = original;
    }
    protected override void TakeDamage(int damage)
    {
        currentHealth -= damage;
        HandleFeedBackDamage();
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    protected override void Die()
    {
        base.Die();
    }
    public override void DestroyEntity()
    {
        base.DestroyEntity();
        UI.instance.EnableGameOverUI();
    }
    private void HandleFeedBackDamage()
    {
        if (DamageFeedback != null)
        {
            StopCoroutine(DamageFeedback);
        }
        StartCoroutine(damageFeedback());
    }
}
