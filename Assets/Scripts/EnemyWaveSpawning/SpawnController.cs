using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    private SpawnerState currentState = new IdleState();
    [SerializeField] private int swarmsPerRound;
    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private Transform[] spawnPoints;

    private float spawnProbability = 0.3f;
    private int currentWave = 0;

    private List<GameObject> currentEnemies = new List<GameObject>();


    void Update()
    {
        updateState();
    }

    private void updateState()
    {
        SpawnerState newState = currentState.Tick(this);
        if (newState != null)
        {
            currentState.Exit();
            currentState = newState;
            currentState.Enter();
        }
    }

   

    public void spawnSurge()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            float chanceToSpawn = Random.Range(0f, 1f);
            if(chanceToSpawn < (1 - spawnProbability)) continue;

            Transform point = spawnPoints[i];
            int maxEnemyIndex;
            switch(currentWave)
            {
                case 0:
                    maxEnemyIndex = 0;
                    break;
                case 1:
                    maxEnemyIndex = 1;
                    break;
                default:
                    maxEnemyIndex = enemyPrefabs.Count - 1;
                    break;
            }

            GameObject enemy = Instantiate(enemyPrefabs[Random.Range(0, maxEnemyIndex)], point.position, point.rotation);

            enemy.GetComponent<Healthbehaviour>().onDeath.AddListener((removeEnemy));
            enemy.GetComponent<Healthbehaviour>().onDeath.AddListener(ScoreManager.instance.addScore);
            currentEnemies.Add(enemy);
        }
    }

    public void removeEnemy(GameObject enemy)
    {
        currentEnemies.Remove(enemy);
    }

    public int SwarmsPerRound => swarmsPerRound;

    

    public void setSwarmsPerRound(int newSwarmsPerRound)
    {
        swarmsPerRound = newSwarmsPerRound;
    }

    public void incrementWaveNumber()
    {
        currentWave++;
    }
}
