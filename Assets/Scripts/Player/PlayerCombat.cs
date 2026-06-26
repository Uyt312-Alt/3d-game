using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("Sword")]
    public Animator swordAnimator;
    public float attackRange = 2.5f;
    public float attackDamage = 35f;
    public float attackCooldown = 0.6f;
    public LayerMask enemyMask;
    public Camera playerCamera;

    private float lastAttackTime = -999f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= lastAttackTime + attackCooldown)
        {
            lastAttackTime = Time.time;
            if (swordAnimator) swordAnimator.SetTrigger("Attack");
            Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            if (Physics.Raycast(ray, out RaycastHit hit, attackRange, enemyMask))
                hit.collider.GetComponent<EnemyHealth>()?.TakeDamage(attackDamage);
        }
    }
}
