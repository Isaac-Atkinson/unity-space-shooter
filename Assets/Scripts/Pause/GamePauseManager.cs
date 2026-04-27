using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;


public class GamePauseManager : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenuPanel;

    public static GamePauseManager instance { get; private set; }
    private InputAction pauseAction;

    private Boolean isPaused = false;


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

        pauseAction = InputSystem.actions.FindAction("Pause");
    }

    public void togglePause()
    {
        Debug.Log("Toggling pause");

        if (isPaused)
        {
            Time.timeScale = 1f;
            isPaused = false;
            pauseMenuPanel.SetActive(false);
        }
        else
        {
            Time.timeScale = 0f;
            isPaused = true;
            pauseMenuPanel.SetActive(true);
        }
    }

    private void Update()
    {
        if (pauseAction != null && pauseAction.WasPressedThisFrame())
            togglePause();

    }

    public bool IsPaused()
    {
        return isPaused;
    }

    public void onGameOver()
    {
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void onExit()
    {
        isPaused = false;
        Time.timeScale = 1f;
    }
}