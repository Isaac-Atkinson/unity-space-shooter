using UnityEngine;

public class AudioBehaviour : MonoBehaviour
{
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip fireSound;
    [SerializeField] private AudioClip damageSound;
    [SerializeField] private AudioClip powerUpSound;
    [SerializeField] private AudioClip hitBoundary;
    [SerializeField] private AudioClip powerDownSound;


    private void Awake()
    {
        PowerUpManager.instance.onPowerUpExpired.AddListener(onPowerDown);
    }
    public void onDeath(GameObject obj)
    {
        if(deathSound != null)
        {
            SoundManager.instance.playSound(deathSound);

        }
    }

    public void onFire()
    {
        if(fireSound != null)
        {
            SoundManager.instance.playSound(fireSound);

        }
    }

    public void onDamage(int damage)
    {
        if (damageSound != null)
        {
            SoundManager.instance.playSound(damageSound);

        }
    }

    public void onPowerUp()
    {
        if (powerUpSound != null)
        {
            SoundManager.instance.playSound(powerUpSound);
        }
    }

    public void onHitBoundary()
    {
        if (hitBoundary != null)
        {
            SoundManager.instance.playSound(hitBoundary);
        }
    }

    public void onPowerDown()
    {
        if (powerDownSound != null)
        {
            SoundManager.instance.playSound(powerDownSound);
        }
    }
}
