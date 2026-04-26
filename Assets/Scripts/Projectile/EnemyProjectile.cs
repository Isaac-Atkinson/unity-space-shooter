using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 10f;
    [SerializeField] private int damage = 10;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.linearVelocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement playerMovement = collision.GetComponent<PlayerMovement>();
        if (playerMovement)
        {
            
            Healthbehaviour healthbehaviour = collision.GetComponent<Healthbehaviour>();
            if (healthbehaviour) healthbehaviour.addHealth(-damage);
            hitSomething();
        }
        
    }

    private void hitSomething()
    {
        gameObject.SetActive(false);
    }

    public float Speed => speed;

    void Update()
    {

    }
}
