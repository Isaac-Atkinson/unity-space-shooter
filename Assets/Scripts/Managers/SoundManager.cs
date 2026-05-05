using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }

    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource musicSource;

    [SerializeField] private AudioClip music;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        playMusic();
    }

    void Start()
    {
        
    }

    public void playSound(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    private void playMusic()
    {
        musicSource.clip = music;
        musicSource.Play();
    }

    public void stopMusic()
    {
        musicSource.Stop();
    }


}
