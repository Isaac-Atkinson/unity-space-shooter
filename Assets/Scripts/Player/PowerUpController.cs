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

        Color subtleColor = Color.Lerp(Color.white, type.color, 0.5f);
        StartCoroutine(applyColourTint(subtleColor, type.duration));
        switch (type.effect)
        {
            case PowerUpType.PowerUpEffect.damageBoost:
                StartCoroutine(fireBehaviour.ApplyDamageBoost(type.duration, type.multiplier));
                break;
            case PowerUpType.PowerUpEffect.speedBoost:
                StartCoroutine(playerMovement.ApplySpeedBoost(type.duration, type.multiplier));
                break;
            case PowerUpType.PowerUpEffect.healthBoost:
                StartCoroutine(healthBehaviour.ApplyHealthBoost(type.duration, type.multiplier));
                break;
            case PowerUpType.PowerUpEffect.scoreBoost:
                StartCoroutine(ScoreManager.instance.ApplyScoreBoost(type.duration, type.multiplier));
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
