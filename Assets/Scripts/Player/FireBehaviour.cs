using UnityEngine;
using UnityEngine.InputSystem;

public class FireBehaviour : MonoBehaviour
{


    private InputAction moveAction;
    private Rigidbody2D rb;
    private Transform tr;
    [SerializeField] private Transform spawn;
    [SerializeField] private ProjectileBehaviour fireball_prefab;

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
        if (moveAction != null && moveAction.triggered) {
            Fire();
        }
    }

    
    private void Fire()
    {
        Instantiate(fireball_prefab, spawn.position, tr.rotation);
    }
}
