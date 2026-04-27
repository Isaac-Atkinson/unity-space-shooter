using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void onGameOver()
    {
        GamePauseManager.instance.onGameOver();
        gameOverPanel.SetActive(true);
    }
}
