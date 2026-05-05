using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager instance { get; private set; }

    private PowerUpType activePowerUp;
    private PowerUpUI powerUpUI;

    public UnityEvent onPowerUpExpired;


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
    }
    void Start()
    {
        activePowerUp = null;
        powerUpUI = GetComponent<PowerUpUI>();
    }

    

    public void addPowerUp(PowerUpType type)
    {
        Debug.Log("Adding power-up: " + type.name);
        activePowerUp = type;
        powerUpUI.addPowerUp(type);
        
        StartCoroutine(Timer(type.Duration));
    }

    private IEnumerator Timer(int duration)
    {
        yield return new WaitForSeconds(duration);

        activePowerUp = null;
        onPowerUpExpired?.Invoke();

    }

    public bool canSpawnPowerUp()
    {
        return activePowerUp == null;
    }

    

    
}
