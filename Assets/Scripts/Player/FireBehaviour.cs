using UnityEngine;
using UnityEngine.InputSystem;

public class FireBehaviour : MonoBehaviour
{


    private InputAction moveAction;
    private Transform tr;
    [SerializeField] private Transform spawn;
    [SerializeField] private ProjectileBehaviour fireball_prefab;

    private void Awake()
    {
        tr = transform;

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
        Debug.Log("Fire");
    }
}
