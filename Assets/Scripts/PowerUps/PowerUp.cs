using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private PowerUpType type;
    private int duration;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = type.sprite;
        duration = type.duration;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PowerUpController powerUpController = other.GetComponent<PowerUpController>();
        if (powerUpController != null)
        {
            powerUpController.activatePowerUp(type);
            Destroy(gameObject);
        }
    }
}
