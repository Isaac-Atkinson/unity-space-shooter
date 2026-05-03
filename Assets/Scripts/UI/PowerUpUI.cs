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
    [SerializeField] private GameObject powerUpCollectedPanel;
    
    private float powerUpCollectedDisplayTime = 1f;



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
        effectPanel.SetActive(false);
    }
    public void showUI(PowerUpType type)
    {
        GameObject panel = Instantiate(effectPanel, canvas);
        Image powerUpIcon = panel.GetComponentInChildren<Image>();
        powerUpIcon.sprite = type.sprite;
        TextMeshProUGUI timer = panel.GetComponentInChildren<TextMeshProUGUI>();
        StartCoroutine(Timer(type.duration, timer));
    }

    public void showPowerUpCollectedUI(PowerUpType type)
    {
        StartCoroutine(animatePowerUpCollectedUI(type));

    }

    private IEnumerator animatePowerUpCollectedUI(PowerUpType type)
    {
        GameObject panel = Instantiate(powerUpCollectedPanel, canvas);
        TextMeshProUGUI text = panel.GetComponentInChildren<TextMeshProUGUI>();
        text.text = "+ " + type.effect.ToString();

        yield return new WaitForSeconds(powerUpCollectedDisplayTime);

        Destroy(panel);
    }
}
