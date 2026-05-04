using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviour : MonoBehaviour
{
    [SerializeField] private Image healthBarForeground;

    private int maxHealth;

    private void Start()
    {
        Healthbehaviour healthbehaviour = GetComponentInParent<Healthbehaviour>();
        if (healthbehaviour != null)
        {
            maxHealth = healthbehaviour.MaxHealth;
            Debug.Log("Max health set to: " + maxHealth);
        }
    }

    public void updateHealthBar(string health)
    {
        Debug.Log("Updating health bar with health: " + health);
        Debug.Log(int.Parse(health) / maxHealth);
        healthBarForeground.fillAmount = float.Parse(health) / maxHealth;
    }
}
