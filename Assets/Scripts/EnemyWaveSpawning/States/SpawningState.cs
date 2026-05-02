using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class SpawningState : SpawnerState
{

    

    private SpawnController SpawnController;


    private int swarmsSpawned = 0;
    private int timeBetweenSwarms = 5;
    private float spawnTimer;

    public SpawningState(SpawnController spawnController)
    {
        this.SpawnController = spawnController;
    }

    public SpawnerState Tick(SpawnController spawnController)
    {
        spawnTimer += Time.deltaTime;
        if(spawnTimer >= timeBetweenSwarms && swarmsSpawned < spawnController.SwarmsPerRound)
        {
            spawnController.spawnSurge();
            spawnTimer = 0;
            swarmsSpawned++;
        }

        if (spawnController.AllEnemiesGone() && swarmsSpawned >= spawnController.SwarmsPerRound)
        {
            spawnController.incrementWaveNumber();

            return new IdleState();
        }
        return null;
    }

    public void Enter()
    {
        SpawnController.spawnSurge();
        swarmsSpawned++;
        spawnTimer = 0;
    }

    public void Exit()
    {

    }
}
