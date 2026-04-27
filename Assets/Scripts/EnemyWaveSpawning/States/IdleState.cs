using UnityEditor;
using UnityEngine;

public class IdleState : SpawnerState
{
    private float timer = 0f;
    private float idleTime = 2f;

    
    public SpawnerState Tick(SpawnController spawnController)
    {
        timer += Time.deltaTime;
        if (timer >= idleTime) return new SpawningState(spawnController);
        
        return null;
    }

    public void Enter()
    {
        
    }

    public void Exit()
    {
        
    }
}