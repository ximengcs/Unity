using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    private void Start() {
        currentHealth = maxHealth;
        healthBar.SetMaxValue(maxHealth);
        healthBar.SetHealth(currentHealth);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            DemageHealth(10);
        }
    }

    private void DemageHealth(int damage) {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
