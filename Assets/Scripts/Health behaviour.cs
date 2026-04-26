using UnityEngine;
using UnityEngine.Events;

public class Healthbehaviour : MonoBehaviour
{

    public UnityEvent<string> onHealthChange;
    public UnityEvent<int> onDeath;

    [SerializeField] private int maxHealth;
    private int currentHealth;


    private void Awake()
    {
        currentHealth = maxHealth;
        onHealthChange?.Invoke(currentHealth.ToString());

    }
    public void addHealth(int health)
    {
        currentHealth += health;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        onHealthChange?.Invoke(currentHealth.ToString());
        if (currentHealth <= 0) Die();
    }

    private void Die()
    {
        onDeath?.Invoke(maxHealth);
        gameObject.SetActive(false);
    }
}
