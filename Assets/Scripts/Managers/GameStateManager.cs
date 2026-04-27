using System;
using System.Collections;
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
        StartCoroutine(HandleGameOver());
    }

    private IEnumerator HandleGameOver()
    {
        yield return new WaitForSeconds(1f);
        GamePauseManager.instance.onGameOver();
        gameOverPanel.SetActive(true);
    }
}
