using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    [SerializeField] private float duration;
    void Start()
    {
        Destroy(gameObject, duration);
    }

    
}
