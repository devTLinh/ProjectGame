using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    private Player player;
    private void Awake()
    {
        player = GetComponentInParent<Player>();
    }
    private void DisableJumpAndMovement() => player.EnableMovement(false);
    private void EnableJumpAndMovement() => player.EnableMovement(true);
    private void DamageEnemies() => player.DamageTargets();
}
