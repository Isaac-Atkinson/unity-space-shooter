using UnityEngine;

public class BoundaryBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("EnemyDetectionWall"))
        {
            
            ScoreManager.instance.subtractScore(gameObject);
            SpawnController spawnController = FindFirstObjectByType<SpawnController>();
            spawnController.removeEnemy(gameObject);
            Destroy(gameObject);

        }

    }
}
