using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PowerUpController : MonoBehaviour
{

    public UnityEvent<PowerUpType> onPowerUpActivated;

    private SpriteRenderer spriteRenderer;
    private PlayerMovement playerMovement;
    private Healthbehaviour healthBehaviour;
    private FireBehaviour fireBehaviour;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerMovement = GetComponent<PlayerMovement>();
        healthBehaviour = GetComponent<Healthbehaviour>();
        fireBehaviour = GetComponent<FireBehaviour>();
    }
    public void activatePowerUp(PowerUpType type)
    {
        onPowerUpActivated?.Invoke(type);

        Color subtleColor = Color.Lerp(Color.white, type.Color, 0.5f);
        StartCoroutine(applyColourTint(subtleColor, type.Duration));
        switch (type.Effect)
        {
            case PowerUpType.PowerUpEffect.damageBoost:
                StartCoroutine(fireBehaviour.ApplyDamageBoost(type.Duration, type.Multiplier));
                break;
            case PowerUpType.PowerUpEffect.shieldBoost:
                StartCoroutine(healthBehaviour.ApplyShieldBoost(type.Duration, type.Multiplier));
                break;
            case PowerUpType.PowerUpEffect.scoreBoost:
                StartCoroutine(ScoreManager.instance.ApplyScoreBoost(type.Duration, type.Multiplier));
                break;
            case PowerUpType.PowerUpEffect.speedBoost:
                StartCoroutine(playerMovement.ApplySpeedBoost(type.Duration, type.Multiplier));
                break;
        }
    }

    private IEnumerator applyColourTint(Color color, int duration)
    {
        spriteRenderer.color = color;
        yield return new WaitForSeconds(duration);
        spriteRenderer.color = Color.white;
    }
}
