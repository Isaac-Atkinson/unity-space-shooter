using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    private SpawnerState currentState = new IdleState();
    [SerializeField] private int enemiesPerRound;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] spawnPoints;

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

    public void SpawnEnemy()
    {
        Transform point = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject enemy = Instantiate(enemyPrefab, point.position, point.rotation);

        enemy.GetComponent<Healthbehaviour>().onDeath.AddListener((removeEnemy));
        enemy.GetComponent<Healthbehaviour>().onDeath.AddListener(ScoreManager.instance.addScore);


        currentEnemies.Add(enemy);
    }

    public void removeEnemy(GameObject enemy)
    {
        currentEnemies.Remove(enemy);
    }

    public int EnemiesPerRound => enemiesPerRound;

    public bool AllEnemiesKilled()
    {
        return currentEnemies.Count == 0;
    }

    public void setEnemiesPerRound(int newEnemiesPerRound)
    {
        enemiesPerRound = newEnemiesPerRound;
    }
}
