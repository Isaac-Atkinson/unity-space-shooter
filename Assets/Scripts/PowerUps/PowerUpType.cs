using UnityEngine;

[CreateAssetMenu(fileName = "PowerUpType", menuName = "Scriptable Objects/PowerUpType")]
public class PowerUpType : ScriptableObject
{
    public Sprite sprite;
    public int duration;
    public float multiplier;
    public Color color;
    public PowerUpEffect effect;

    public enum PowerUpEffect
    {
        damageBoost,
        speedBoost,
        scoreBoost,
        healthBoost,
    }
}
