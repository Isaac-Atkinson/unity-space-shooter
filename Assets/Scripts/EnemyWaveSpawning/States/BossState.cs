using UnityEngine;

public class BossState : SpawnerState
{
    float timer;
    float timeUntilSpawn;
    bool isSpawned;
    public SpawnerState Tick(SpawnController spawnController)
    {
        //if (!isSpawned)
        //{
        //    timer += Time.deltaTime;
        //    if(timer > timeUntilSpawn)
        //    {
        //        spawnController.spawnBoss();
        //        isSpawned = true;
        //    }
        //}

        if(spawnController.isBossDefeated()) return new IdleState();
        return null;
    }
    public void Enter(SpawnController spawnController)
    {
        //timer = 0;
        //timeUntilSpawn = 2f;
        //isSpawned = false;

        spawnController.spawnBoss();
    }
    public void Exit(SpawnController spawnController)
    {

    }
}
