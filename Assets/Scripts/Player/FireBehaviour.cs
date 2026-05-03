using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class FireBehaviour : MonoBehaviour
{
    public UnityEvent onFire;

    private InputAction moveAction;
    private Rigidbody2D rb;
    private Transform tr;
    [SerializeField] private int damage = 10;
    [SerializeField] private Transform spawn;
    [SerializeField] private ProjectileBehaviour fireball_prefab;
    [SerializeField] private GamePauseManager gamePauseManager;

    private void Awake()
    {
        tr = transform;
        rb = GetComponent<Rigidbody2D>();

    }
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Attack");
    }

    // Update is called once per frame
    void Update()
    {
        if (moveAction != null && moveAction.triggered)
        {
            if (gamePauseManager != null && !gamePauseManager.IsPaused())
            {
                Fire();
            }
        }
    }

    
    private void Fire()
    {
        onFire?.Invoke();
        ProjectileBehaviour projectile = Instantiate(fireball_prefab, spawn.position, tr.rotation);
        projectile.setDamage(damage);
    }

    public IEnumerator ApplyDamageBoost(float duration, float multiplier)
    {
        int originalDamage = damage;
        damage = (int)(damage * multiplier);

        yield return new WaitForSeconds(duration);

        damage = originalDamage;
    }
    
}
