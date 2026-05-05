using UnityEngine;

public class BossState : SpawnerState
{
    public SpawnerState Tick(SpawnController spawnController)
    {


        if(spawnController.isBossDefeated()) return new IdleState();
        return null;
    }
    public void Enter(SpawnController spawnController)
    {
        spawnController.spawnBoss();
    }
    public void Exit(SpawnController spawnController)
    {

    }
}
