using System.Collections;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class WaveUI : MonoBehaviour
{
    [SerializeField] private GameObject waveUI;
    

    private void Start()
    {
        
    }

    public void showUI(float duration)
    {
        StartCoroutine(UIAnimation(duration));
    }

    IEnumerator UIAnimation(float duration)
    {
        waveUI.SetActive(true);
        yield return new WaitForSeconds(duration);  
        waveUI.SetActive(false);
    }

    public void updateProgressBar(float progress)
    {
        
    }
}
