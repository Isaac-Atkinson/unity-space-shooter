using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public UnityEvent<string> onScoreChange;
    private int currentScore = 0;

    void Start()
    {
        onScoreChange?.Invoke(currentScore.ToString());
    }
    public void addScore(int score)
    {
        currentScore += score;
        onScoreChange?.Invoke(currentScore.ToString());
    }

    public void onGameOver()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if ((currentScore > highScore))
        {
            PlayerPrefs.SetInt("HighScore", currentScore);

        }
    }
}
