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
    private float shieldMultiplier = 1f;


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
        currentHealth += (int)(health * shieldMultiplier);

        if (currentHealth > maxHealth) currentHealth = maxHealth;
        if (currentHealth < 0) currentHealth = 0;
        if (currentHealth == 0) Die();

        onHealthChange?.Invoke(currentHealth.ToString());
    }

    private void Die()
    {
        
        onDeath?.Invoke(gameObject);
        CancelInvoke();
        Destroy(gameObject);
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        
    }

    public IEnumerator ApplyShieldBoost(float duration, float multiplier)
    {
        shieldMultiplier = multiplier;

        yield return new WaitForSeconds(duration);

        shieldMultiplier = 1f;
    }

    public int MaxHealth => maxHealth;
}