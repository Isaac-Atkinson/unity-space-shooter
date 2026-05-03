using UnityEngine;
using UnityEngine.Events;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private PowerUpType type;
    [SerializeField] private GameObject pickupEffectPrefab;
    
    
    

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = type.sprite;
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PowerUpController powerUpController = other.GetComponent<PowerUpController>();
        if (powerUpController != null)
        {
            powerUpController.activatePowerUp(type);
            Instantiate(pickupEffectPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
