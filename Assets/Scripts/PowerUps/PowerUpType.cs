using UnityEngine;

[CreateAssetMenu(fileName = "PowerUpType", menuName = "Scriptable Objects/PowerUpType")]
public class PowerUpType : ScriptableObject
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private int duration;
    [SerializeField] private float multiplier;
    [SerializeField] private Color color;
    [SerializeField] private PowerUpEffect effect;

    public Sprite Sprite => sprite;
    public int Duration => duration;
    public float Multiplier => multiplier;
    public Color Color => color;
    public PowerUpEffect Effect => effect;

    public enum PowerUpEffect
    {
        damageBoost,
        speedBoost,
        scoreBoost,
        shieldBoost,
    }

    
}
