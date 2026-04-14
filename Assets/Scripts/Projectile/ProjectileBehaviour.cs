using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 10f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Start()
    {
        rb.linearVelocity = transform.up * speed;
    }

    
    void Update()
    {
        
    }
}
