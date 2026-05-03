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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thrustAction = InputSystem.actions.FindAction("Thrust");
        brakeAction = InputSystem.actions.FindAction("Brake");
        leftRotate = InputSystem.actions.FindAction("RotateLeft");
        rightRotate = InputSystem.actions.FindAction("RotateRight");

    }

    // Update is called once per frame
    void Update()
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
        //rb.angularVelocity = Mathf.Clamp(rb.angularVelocity, -maxRotationSpeed, maxRotationSpeed);


        //if (thrustAction != null){

        //    float thrust = thrustAction.ReadValue<float>();
            

        //    rb.AddForce(tr.up * thrust * speed);
        //    if(rb.linearVelocity.magnitude > maxSpeed)
        //    {
        //        rb.linearVelocity = maxSpeed * rb.linearVelocity.normalized;
        //    }
        //} 
        

        //if (brakeAction != null)
        //{

        //    float brake = brakeAction.ReadValue<float>();
        //    //rb.AddForce(tr.up * brake * speed * -1);
        //    rb.AddForce(-rb.linearVelocity * brake * brakeForce);
        //    if (rb.linearVelocity.magnitude > maxSpeed)
        //    {
        //        rb.linearVelocity = maxSpeed * rb.linearVelocity.normalized;
        //    }
        //}
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