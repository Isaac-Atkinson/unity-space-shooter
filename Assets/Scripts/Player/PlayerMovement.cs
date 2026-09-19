using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
    
{

    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float drag;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float maxRotationSpeed;
    [SerializeField] private float brakeForce;

    private InputAction thrustAction;
    private InputAction brakeAction;
    private InputAction leftRotate;
    private InputAction rightRotate;
    private Transform tr;
    private Rigidbody2D rb;

    void Awake()
    {
        tr = transform;
        rb = GetComponent<Rigidbody2D>();
        rb.linearDamping = drag;
    }
    
    void Start()
    {
        thrustAction = InputSystem.actions.FindAction("Thrust");
        brakeAction = InputSystem.actions.FindAction("Brake");
        leftRotate = InputSystem.actions.FindAction("RotateLeft");
        rightRotate = InputSystem.actions.FindAction("RotateRight");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(leftRotate != null)  {
            float left = leftRotate.ReadValue<float>();
            //tr.Rotate(left * rotationSpeed * Vector3.forward);
            //rb.AddTorque(left * rotationSpeed);
            rb.AddForce(-tr.right * left * speed);
        }
        if (rightRotate != null)
        {
            float right = rightRotate.ReadValue<float>();
            //tr.Rotate(right * rotationSpeed * Vector3.forward * -1);
            //rb.AddTorque(right * rotationSpeed * -1);
            rb.AddForce(tr.right * right * speed);
        }
        
    }

    public IEnumerator ApplySpeedBoost(float duration, float multiplier)
    {
        speed *= multiplier;
        maxSpeed *= multiplier;
        rotationSpeed *= multiplier;
        maxRotationSpeed *= multiplier;
        brakeForce *= multiplier;
        
        yield return new WaitForSeconds(duration);

        speed /= multiplier;
        maxSpeed /= multiplier;
        rotationSpeed /= multiplier;
        maxRotationSpeed /= multiplier;
        brakeForce /= multiplier;
    }

    
}