using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject highScoresPanel;
    public void startGame()
    {
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
}
