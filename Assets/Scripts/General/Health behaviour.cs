using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Healthbehaviour : MonoBehaviour
{

    public UnityEvent<string> onHealthChange;
    public UnityEvent<int> onDamaged;
    public UnityEvent<GameObject> onDeath;

    [SerializeField] private int maxHealth;
    [SerializeField] private GameObject explosionPrefab;

    private int currentHealth;


    private void Awake()
    {
        currentHealth = maxHealth;
        onHealthChange?.Invoke(currentHealth.ToString());

    }
    public void addHealth(int health)
    {
        if(health < 0)
        {
            onDamaged?.Invoke(-health);
        }
        currentHealth += health;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        if (currentHealth < 0) currentHealth = 0;
        onHealthChange?.Invoke(currentHealth.ToString());
        if (currentHealth == 0) Die();
    }

    private void Die()
    {
        
        onDeath?.Invoke(gameObject);
        CancelInvoke();
        Destroy(gameObject);
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        
    }

    public IEnumerator ApplyHealthBoost(float duration, float multiplier)
    {
        int originalMaxHealth = maxHealth;

        maxHealth = (int)(maxHealth * multiplier);
        
        int extraHealth = maxHealth - originalMaxHealth;
        addHealth(extraHealth);

        yield return new WaitForSeconds(duration);

        maxHealth = originalMaxHealth;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
    }

    public int MaxHealth => maxHealth;
}