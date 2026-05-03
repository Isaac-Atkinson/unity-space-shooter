using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class OptionsBehaviour : MonoBehaviour
{

    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Toggle fullscreenToggle;
    void Start()
    {
        float volume = PlayerPrefs.GetFloat("Volume", 1f);
        volumeSlider.value = volume;
        AudioListener.volume = volume;

        bool isFullscreen = PlayerPrefs.GetInt("Fullscreen", 1) == 1;
        fullscreenToggle.isOn = isFullscreen;
        Screen.fullScreen = isFullscreen;
    }

    public void setVolume(float volume)
    {
        PlayerPrefs.SetFloat("Volume", volume);
        AudioListener.volume = volume;
    }

    public void setFullscreen(bool isFullscreen)
    {
        PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0);
        Screen.fullScreen = isFullscreen;
    }

}
