using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PowerUpUI : MonoBehaviour
{
    [SerializeField] private GameObject effectPanel;
    [SerializeField] private TextMeshProUGUI timer;
    [SerializeField] private Image powerUpImage;

    [SerializeField] private Sprite speedSprite;
    [SerializeField] private Sprite healthSprite;
    [SerializeField] private Sprite damageSprite;
    [SerializeField] private Sprite scoreSprite;

    public void UpdatePowerUpUI(PowerUpType type)
    {
        switch (type.effect)
        {
            case PowerUpType.PowerUpEffect.speedBoost:
                powerUpImage.sprite = speedSprite;
                break;
            case PowerUpType.PowerUpEffect.healthBoost:
                powerUpImage.sprite = healthSprite;
                break;
            case PowerUpType.PowerUpEffect.damageBoost:
                powerUpImage.sprite = damageSprite;
                break;
            case PowerUpType.PowerUpEffect.scoreBoost:
                powerUpImage.sprite = scoreSprite;
                break;
        }
    }

    public void startTimer(int duration)
    {
        StartCoroutine(Timer(duration));
    }

    private IEnumerator Timer(int duration)
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
    public void showUI()
    {
        effectPanel.SetActive(true);
    }
}
