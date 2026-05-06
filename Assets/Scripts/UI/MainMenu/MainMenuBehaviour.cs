using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject highScoresPanel;
    [SerializeField] private GameObject optionsPanel;

    private void Start()
    {
        mainPanel.SetActive(true);
        highScoresPanel.SetActive(false);
        optionsPanel.SetActive(false);
    }
    public void startGame()
    {
        SoundManager.instance.setMusicVolume(PlayerPrefs.GetFloat("MusicVolume") * 0.7f);
        SceneManager.LoadScene("MainScene");
    }

    public void loadHighScores()
    {
        mainPanel.SetActive(false);
        highScoresPanel.SetActive(true);
    }

    public void hideHighScores()
    {
        mainPanel.SetActive(true);
        highScoresPanel.SetActive(false);
    }

    public void loadOptions()
    {
        mainPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void hideOptions()
    {
        mainPanel.SetActive(true);
        optionsPanel.SetActive(false);
    }
}
