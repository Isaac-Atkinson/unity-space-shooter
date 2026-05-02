using UnityEngine;

public interface SpawnerState
{
    public SpawnerState Tick(SpawnController spawnController);
    public void Enter(SpawnController spawnController);
    public void Exit(SpawnController spawnController);

}
