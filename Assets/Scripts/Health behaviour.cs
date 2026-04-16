using UnityEngine;

public class Healthbehaviour : MonoBehaviour
{
   
    [SerializeField] private int maxHealth;
    private int currentHealth;


    private void Awake()
    {
        currentHealth = maxHealth;

    }
    public void addHealth(int health)
    {
        currentHealth += health;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        if (currentHealth <= 0) Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
