using UnityEngine;

public class EnemyFireBehaviour : MonoBehaviour { 

    private Transform tr;
    [SerializeField] private Transform spawn;
    [SerializeField] private EnemyProjectile enemy_projectile;
    [SerializeField] private float fireTime = 1.0f;

    private float projectileSpeed;
    private PlayerMovement player;
    private Rigidbody2D targetRB;

    private void Fire()
    {
        Instantiate(enemy_projectile, spawn.position, spawn.rotation);
    }

    void Start()
    {
        tr = transform;
        InvokeRepeating("fire", 0f, fireTime);
        instantiate();
    }

    private void FixedUpdate()
    {
        updateRotation();
    }

    private void fire()
    {
        Instantiate(enemy_projectile, spawn.position, tr.rotation);
    }

    private void instantiate()
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

    private void OnEnable()
    {
        InvokeRepeating("fire", 0f, fireTime);
    }

    private void OnDisable()
    {
        CancelInvoke("fire");
    }
}
