using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 60f;
    private float hp;

    void Start() { hp = maxHealth; }

    public void TakeDamage(float dmg)
    {
        hp -= dmg;
        Debug.Log($"{gameObject.name} took {dmg} dmg. HP: {hp}");
        if (hp <= 0) Destroy(gameObject, 0.3f);
    }
}
