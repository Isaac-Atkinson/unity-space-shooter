using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class SpawningState : SpawnerState
{

    

    private SpawnController SpawnController;


    private int swarmsSpawned = 0;
    private int timeBetweenSwarms = 5;
    private float spawnTimer;

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
            return new BossState();
        }
        
        return null;
    }

    public void Enter(SpawnController spawnController)
    {
        spawnTimer = timeBetweenSwarms;
        spawnController.enableProgressBar();
    }

    public void Exit(SpawnController spawnController)
    {
        spawnController.incrementWaveNumber();
        spawnController.disableProgressBar();
    }
}
