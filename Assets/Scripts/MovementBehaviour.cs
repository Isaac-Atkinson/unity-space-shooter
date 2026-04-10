using UnityEngine;
using UnityEngine.InputSystem;

public class MovementBehaviour : MonoBehaviour
    
{

    [SerializeField] private float speed = 5f;

    private InputAction moveAction;
    private Transform tr;
    private Vector2 axisValue;
    private Vector2 moveDistance;

    void Awake()
    {
        tr = transform;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        if (moveAction != null){
            axisValue = moveAction.ReadValue<Vector2>();
            moveDistance = axisValue * speed * Time.deltaTime;
            tr.Translate(moveDistance);
        }
    }
}
