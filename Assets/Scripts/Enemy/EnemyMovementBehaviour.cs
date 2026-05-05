using UnityEngine;

public class EnemyMovementBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D rb;
    void Start()

    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = speed * transform.up;
    }

    
    
}
