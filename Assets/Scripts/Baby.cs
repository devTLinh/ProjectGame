using System.Collections;
using UnityEngine;

public class Baby : Entity
{
    [SerializeField] private Transform player;
    private SpriteRenderer sr;
    private float moveSpeed = 4f;
    private float distanceToPlayer = 4f;
    [SerializeField]private Material damageMaterial;
    private Coroutine DamageFeedback;
    private float damageFlashDuration = .5f;
    private void Awake()
    {
        base.Start();
        sr = GetComponentInChildren<SpriteRenderer>();
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
        Material original = sr.material;
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
