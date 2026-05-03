using System.Collections;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class WaveUI : MonoBehaviour
{
    [SerializeField] private GameObject waveUI;

    private bool isActive;


    private void Start()
    {
        isActive = false;
    }

    public void showUI(float duration)
    {
        StartCoroutine(UIAnimation(duration));
    }

    IEnumerator UIAnimation(float duration)
    {
        waveUI.SetActive(true);
        isActive = true;
        yield return new WaitForSeconds(duration);  
        waveUI.SetActive(false);
        isActive = false;
    }

    public void onTogglePause(bool isPaused)
    {
        if (isActive)
        {
            waveUI.SetActive(!isPaused);

        }
    }
}
