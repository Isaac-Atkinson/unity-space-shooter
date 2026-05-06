using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }

    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource musicSource;

    [SerializeField] private AudioClip music;

    private float musicVolume;
    private float sfxVolume;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
            musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
            sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);
            Debug.Log("sfx: " + sfxVolume);
            musicSource.volume = musicVolume;
            sfxSource.volume = sfxVolume;
            playMusic();
        }
        else
        {
            Destroy(gameObject);
        }

        
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

    public void setMusicVolume(float volume)
    {
        musicSource.volume = volume;
        musicVolume = volume;
    }

    public void setSFXVolume(float volume)
    {
        sfxSource.volume = volume;
        sfxVolume = volume;
    }


}
