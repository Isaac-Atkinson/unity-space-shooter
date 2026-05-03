using UnityEngine;

public class AudioBehaviour : MonoBehaviour
{
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip fireSound;
    [SerializeField] private AudioClip damageSound;

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
}
