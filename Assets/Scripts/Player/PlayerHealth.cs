using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth { get; private set; }
    public UnityEvent onDeath;

    void Start() { currentHealth = maxHealth; }

    public void TakeDamage(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth - amount, 0, maxHealth);
        if (currentHealth <= 0) onDeath?.Invoke();
    }

    public void Heal(float amount) { currentHealth = Mathf.Min(currentHealth + amount, maxHealth); }
}
