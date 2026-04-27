using UnityEngine;

public class WallLogic : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyFireBehaviour enemyFireBehaviour = collision.GetComponent<EnemyFireBehaviour>();
        if (enemyFireBehaviour)
        {
            collision.gameObject.SetActive(false);
            ScoreManager.instance.subtractScore(collision.gameObject);
        }
        
    }
}
