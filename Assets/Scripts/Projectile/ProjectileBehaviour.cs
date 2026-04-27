using Unity.VisualScripting;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 10f;
    private int damage = 0;

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
        if (!playerMovement)
        {
            Healthbehaviour healthbehaviour = collision.GetComponent<Healthbehaviour>();
            if (healthbehaviour) healthbehaviour.addHealth(-damage);
            Debug.Log("Did damage: " + damage);
            hitSomething();
        }


    }

    private void hitSomething()
    {
        gameObject.SetActive(false);
    }


    void Update()
    {
        
    }

    public void setDamage(int newDamage)
    {
        Debug.Log("Setting damage: " + newDamage);
        damage = newDamage;
    }
}
