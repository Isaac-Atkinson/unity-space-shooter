using UnityEngine;

public class BossMovementBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float timeBetweenChangeDirection;

    private float timer;

    private Rigidbody2D rb;
    void Start()

    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = speed * transform.up;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeBetweenChangeDirection)
        {
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            rb.linearVelocity = speed * randomDirection;
            timer = 0;
        }
    }
}
