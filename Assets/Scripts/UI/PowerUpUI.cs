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
    private PowerUpType activePowerUp = null;

    [SerializeField] private GameObject powerUPIcon;
    [SerializeField] private TextMeshProUGUI powerUpTimer;


    
    public void Start()
    {
        powerUPIcon.SetActive(false);
        
    }

    private IEnumerator Timer(int duration)
    {
        float timeLeft = duration;
        while (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            powerUpTimer.text = Mathf.Ceil(timeLeft).ToString();
            yield return null;
        }
        activePowerUp = null;
        powerUPIcon.SetActive(false);
        powerUpTimer.text = "";
    }
    
    public void addPowerUp(PowerUpType type)
    {
        Debug.Log("Showing UI for power-up: " + type.name);
        activePowerUp = type;
        powerUPIcon.SetActive(true);
        powerUPIcon.GetComponent<Image>().sprite = type.Sprite;
        StartCoroutine(Timer(type.Duration));
        showPowerUpCollectedUI(type);

    }

    public void showPowerUpCollectedUI(PowerUpType type)
    {
        StartCoroutine(animatePowerUpCollectedUI(type));

    }

    private IEnumerator animatePowerUpCollectedUI(PowerUpType type)
    {
        GameObject panel = Instantiate(powerUpCollectedPanel, canvas);
        TextMeshProUGUI text = panel.GetComponentInChildren<TextMeshProUGUI>();
        text.text = "+ " + type.Effect.ToString();

        yield return new WaitForSeconds(powerUpCollectedDisplayTime);

        Destroy(panel);
    }
}
