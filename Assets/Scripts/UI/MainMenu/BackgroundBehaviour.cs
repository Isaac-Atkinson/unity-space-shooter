using UnityEngine;

public class BackgroundBehaviour : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 1f;

    
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
