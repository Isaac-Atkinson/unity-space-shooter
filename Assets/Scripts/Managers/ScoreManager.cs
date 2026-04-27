using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance { get; private set; }

    public UnityEvent<string> onScoreChange;
    private int currentScore = 0;
    private int numHighScores = 5;

    private float scoreMultiplier = 1.0f;

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
        onScoreChange?.Invoke(currentScore.ToString());
    }
    public void addScore(GameObject enemy)
    {
        int score = enemy.GetComponent<Healthbehaviour>().MaxHealth;
        currentScore += (int) (score * scoreMultiplier);
        onScoreChange?.Invoke(currentScore.ToString());
    }

    public void subtractScore(GameObject enemy)
    {
        int score = enemy.GetComponent<Healthbehaviour>().MaxHealth;
        currentScore -= (int)(score * scoreMultiplier);
        currentScore = Mathf.Max(currentScore, 0);
        onScoreChange?.Invoke(currentScore.ToString());
    }

    public void onGameOver()
    {

        int score = currentScore;
        for (int i = 0; i < numHighScores; i++)
        {
            int storedScore = PlayerPrefs.GetInt("HighScore" + i, 0);
            if (score > storedScore)
            {
                PlayerPrefs.SetInt("HighScore" + i, score);
                score = storedScore;
            }
        }
    }

    public IEnumerator ApplyScoreBoost(float duration, float multiplier)
    {
        scoreMultiplier = multiplier;
        yield return new WaitForSeconds(duration);
        scoreMultiplier = 1.0f;
    }


}
