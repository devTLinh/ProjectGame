using UnityEngine;

public class EntityAnimationEvents : MonoBehaviour
{
    private Entity entity;
    private void Awake()
    {
        entity = GetComponentInParent<Entity>();
    }
    private void DisableMovement() => entity.EnableMovement(false);
    private void EnableMovement() => entity.EnableMovement(true);
    private void EnableAttack() => entity.EnableAttack(true);
    private void DisableAttack() => entity.EnableAttack(false);
    private void DisableActivity() => entity.DestroyEntity();
    private void DamageEnemies() => entity.DamageTargets();
}
