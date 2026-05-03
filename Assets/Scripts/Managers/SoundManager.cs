using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }

    private AudioSource sfxSource;
    private AudioSource musicSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        sfxSource = GetComponent<AudioSource>();
    }

    public void playSound(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    
}
