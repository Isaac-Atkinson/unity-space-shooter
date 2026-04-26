using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
