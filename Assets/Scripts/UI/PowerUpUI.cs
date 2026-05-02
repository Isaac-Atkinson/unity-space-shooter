using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PowerUpUI : MonoBehaviour
{
    [SerializeField] private GameObject effectPanel;
    [SerializeField] private Transform canvas;



    private void Awake()
    {
        
    }


    private IEnumerator Timer(int duration, TextMeshProUGUI timer)
    {
        float timeLeft = duration;
        while (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timer.text = Mathf.Ceil(timeLeft).ToString();
            yield return null;
        }
        Destroy(effectPanel);
    }
    public void showUI(PowerUpType type)
    {
        GameObject panel = Instantiate(effectPanel, canvas);
        Image powerUpIcon = panel.GetComponentInChildren<Image>();
        powerUpIcon.sprite = type.sprite;
        TextMeshProUGUI timer = panel.GetComponentInChildren<TextMeshProUGUI>();
        StartCoroutine(Timer(type.duration, timer));
    }
}
