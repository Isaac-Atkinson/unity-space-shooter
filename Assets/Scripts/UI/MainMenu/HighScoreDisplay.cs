using UnityEngine;

public class HighScoreDisplay : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI highScore0;
    [SerializeField] private TMPro.TextMeshProUGUI highScore1;
    [SerializeField] private TMPro.TextMeshProUGUI highScore2;
    [SerializeField] private TMPro.TextMeshProUGUI highScore3;
    [SerializeField] private TMPro.TextMeshProUGUI highScore4;


    private void Start()
    {
        updateHighScores();
    }

    public void resetHighScores()
    {
        PlayerPrefs.SetInt("HighScore0", 0);
        PlayerPrefs.SetInt("HighScore1", 0);
        PlayerPrefs.SetInt("HighScore2", 0);
        PlayerPrefs.SetInt("HighScore3", 0);
        PlayerPrefs.SetInt("HighScore4", 0);
        updateHighScores();
    }

    private void updateHighScores()
    {
        int highScore = PlayerPrefs.GetInt("HighScore0", 0);
        highScore0.text = highScore.ToString();
        highScore = PlayerPrefs.GetInt("HighScore1", 0);
        highScore1.text = highScore.ToString();
        highScore = PlayerPrefs.GetInt("HighScore2", 0);
        highScore2.text = highScore.ToString();
        highScore = PlayerPrefs.GetInt("HighScore3", 0);
        highScore3.text = highScore.ToString();
        highScore = PlayerPrefs.GetInt("HighScore4", 0);
        highScore4.text = highScore.ToString();
    }

}
