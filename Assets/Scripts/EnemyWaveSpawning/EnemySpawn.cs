using UnityEngine;

[CreateAssetMenu(fileName = "EnemySpawn", menuName = "Scriptable Objects/EnemySpawn")]
public class EnemySpawn : ScriptableObject
{
    public GameObject enemyPrefab;
    public float spawnProbability;
    public int unlockWave;
}
