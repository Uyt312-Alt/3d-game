using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Slider healthSlider;

    void Start() { if (playerHealth && healthSlider) healthSlider.maxValue = playerHealth.maxHealth; }
    void Update() { if (playerHealth && healthSlider) healthSlider.value = playerHealth.currentHealth; }
}
