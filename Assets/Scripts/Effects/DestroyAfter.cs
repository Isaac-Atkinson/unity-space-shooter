using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    [SerializeField] private float timeToDestroy = 1f;
    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }

    
}
