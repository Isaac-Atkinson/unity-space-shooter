using UnityEngine;

public class HighScoreDisplay : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI highScoreText;

    private void Start()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = highScore.ToString();
    }
}
