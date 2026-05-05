using UnityEngine;
using UnityEngine.Events;

public class EnemyFireBehaviour : MonoBehaviour { 

    private Transform tr;
    [SerializeField] private Transform spawn;
    [SerializeField] private EnemyProjectile enemy_projectile;
    [SerializeField] private float fireTime = 1.0f;
    [SerializeField] private FireType fireType;

    public UnityEvent onFire;

    private enum FireType{
        None,
        Targeted,
        Straight
    }

    private float projectileSpeed;
    private PlayerMovement player;
    private Rigidbody2D targetRB;

    

    void Start()
    {
        tr = transform;
        initialise();
        switch(fireType)
        {
            case FireType.None:
                break;
            case FireType.Targeted:
                InvokeRepeating("fire", 0f, fireTime);
                break;
            case FireType.Straight:
                InvokeRepeating("fire", 0f, fireTime);
                break;
        }

    }

    private void FixedUpdate()
    {
        switch(fireType)
        {
            case FireType.Targeted:
                updateRotation();
                break;
            case FireType.Straight:
                break;
        }
    }

    private void fire()
    {
        Instantiate(enemy_projectile, spawn.position, tr.rotation);
        onFire?.Invoke();
        Debug.Log("Firing");
    }

    private void initialise()
    {
        projectileSpeed = enemy_projectile.Speed;
        player = FindFirstObjectByType<PlayerMovement> ();
        targetRB = player.GetComponent<Rigidbody2D>();
    }

    private void updateRotation()
    {

        Vector2 targetPos = targetRB.transform.position;
        Vector2 myPos = tr.position;

        Vector2 direction = (targetPos - myPos);
        float distToPlayer = direction.magnitude;
        float timeToHit = distToPlayer/ projectileSpeed;

        Vector2 targetDirection = (targetPos + targetRB.linearVelocity * timeToHit -  myPos)
                                  / (projectileSpeed * timeToHit);
        targetDirection.Normalize();

       tr.up = targetDirection;

    }

    
}
