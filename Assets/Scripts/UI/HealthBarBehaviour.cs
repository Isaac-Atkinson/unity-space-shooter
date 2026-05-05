using System.Collections;
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
        }
    }

    public void updateHealthBar(string health)
    {
        healthBarForeground.fillAmount = float.Parse(health) / maxHealth;
    }

    public IEnumerator setShieldHealthBar(float duration)
    {
        Color originalColor = healthBarForeground.color;
        healthBarForeground.color = Color.blue; 
        yield return new WaitForSeconds(duration);
        healthBarForeground.color = originalColor;
    }
}
