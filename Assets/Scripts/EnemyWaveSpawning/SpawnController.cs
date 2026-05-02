using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class SpawnController : MonoBehaviour
{
    public UnityEvent<string> onWaveChange;

    [SerializeField] private int swarmsPerRound;
    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnProbability = 0.3f;

    private SpawnerState currentState = new IdleState();
    private int currentWave = 1;

    private List<GameObject> currentEnemies = new List<GameObject>();


    private void Start()
    {
        onWaveChange?.Invoke(currentWave.ToString());
    }
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
            int maxEnemyIndex = Mathf.Min(currentWave - 1, enemyPrefabs.Count - 1);
            

            GameObject enemy = Instantiate(enemyPrefabs[Random.Range(0, maxEnemyIndex + 1)], point.position, point.rotation);

            enemy.GetComponent<Healthbehaviour>().onDeath.AddListener((removeEnemy));
            enemy.GetComponent<Healthbehaviour>().onDeath.AddListener(ScoreManager.instance.addScore);
            currentEnemies.Add(enemy);
        }
    }

    public void removeEnemy(GameObject enemy)
    {
        Debug.Log("Removing enemy" );
        currentEnemies.Remove(enemy);
    }

    public int SwarmsPerRound => swarmsPerRound;

    public bool AllEnemiesGone()
    {
        return currentEnemies.Count == 0;
    }

    

    public void incrementWaveNumber()
    {
        currentWave++;
        onWaveChange?.Invoke(currentWave.ToString());
        swarmsPerRound++;
    }
}
