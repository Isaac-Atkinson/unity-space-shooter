using UnityEngine;
using UnityEngine.VFX;

public class WavePreviewState : SpawnerState
{
    private float displayTime = 2.0f;
    private float timer = 0f;
    public SpawnerState Tick(SpawnController spawnController)
    {
        timer += Time.deltaTime;
        if (timer >= displayTime) return new SpawningState();
        
        return null;
    }

    public void Enter(SpawnController spawnController)
    {
        WaveUI waveUI = spawnController.GetComponent<WaveUI>();
        waveUI.showUI(displayTime);
    }
    public void Exit(SpawnController spawnController)
    {

    }
}

