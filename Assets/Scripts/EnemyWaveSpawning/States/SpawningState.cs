using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawningState : SpawnerState
{
    private SpawnController SpawnController;

    private int enemiesSpawned = 0;
    private int timeBetweenSpawns = 2;
    private float spawnTimer;

    public SpawningState(SpawnController spawnController)
    {
        this.SpawnController = spawnController;
    }

    public SpawnerState Tick(SpawnController spawnController)
    {
        spawnTimer += Time.deltaTime;
        if(spawnTimer >= timeBetweenSpawns && enemiesSpawned < spawnController.EnemiesPerRound)
        {
            spawnController.SpawnEnemy();
            spawnTimer = 0;
            enemiesSpawned++;
        }

        if(spawnController.AllEnemiesKilled()) return new IdleState();
        return null;
    }

    public void Enter()
    {
        SpawnController.SpawnEnemy();
        enemiesSpawned++;
        spawnTimer = 0;
    }

    public void Exit()
    {

    }
}
