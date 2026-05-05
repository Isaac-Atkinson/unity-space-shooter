using NUnit.Framework;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.UI;


public class SpawnController : MonoBehaviour
{
    public UnityEvent<string> onWaveChange;

    [SerializeField] private int swarmsPerRound;
    [SerializeField] private List<EnemySpawn> enemyspawns;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Slider waveProgressBar;

    [SerializeField] private List<GameObject> bosses;
    [SerializeField] private Transform bossSpawn;

    private SpawnerState currentState = new IdleState();
    private int currentWave = 1;
    

    private List<GameObject> currentEnemies = new List<GameObject>();
    private GameObject activeBoss;

    private void Awake()
    {
        activeBoss = null;
    }
    private void Start()
    {
        onWaveChange?.Invoke(currentWave.ToString());
        disableProgressBar();
        Color color = new Color(142 /255f, 46 / 255f, 96 / 255f);
        waveProgressBar.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = color;

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
            currentState.Exit(this);
            currentState = newState;
            currentState.Enter(this);
        }
    }

   

    public void spawnSurge()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
         
            Transform point = spawnPoints[i];

            float totalSpawnProbability = calculateTotalSpawnProbability();
            
            float chance = Random.Range(0f, totalSpawnProbability);

            foreach (EnemySpawn spawn in enemyspawns)
            {

                if (spawn.unlockWave <= currentWave)
                {
                    chance -= spawn.spawnProbability;

                    if (chance < 0)
                    {
                        instanitiateEnemy(spawn, point);
                        break;
                    }
                }
            }
        }
    }

    public void spawnBoss()
    {
        GameObject boss = Instantiate(bosses[0], bossSpawn.position, bossSpawn.rotation);
        activeBoss = boss;
    }

    public void onBossDefeated()
    {
        activeBoss = null;
    }

    public bool isBossDefeated()
    {
        return activeBoss == null;
    }

    private float calculateTotalSpawnProbability()
    {
        float totalSpawnProbability = 0f;
        foreach (EnemySpawn enemySpawn in enemyspawns)
        {
            if (enemySpawn.unlockWave <= currentWave)
            {
                totalSpawnProbability += enemySpawn.spawnProbability;
            }
        }
        return totalSpawnProbability;
    }

    private void instanitiateEnemy(EnemySpawn spawn, Transform point)
    {
        GameObject enemy = Instantiate(spawn.enemyPrefab, point.position, point.rotation);

        enemy.GetComponent<Healthbehaviour>().onDeath.AddListener(removeEnemy);
        enemy.GetComponent<Healthbehaviour>().onDeath.AddListener(ScoreManager.instance.addScore);
        currentEnemies.Add(enemy);
    }

    public void removeEnemy(GameObject enemy)
    {
        currentEnemies.Remove(enemy);
        float progress = ((float) currentEnemies.Count / (spawnPoints.Length * swarmsPerRound));
        waveProgressBar.value = progress;
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

    public void enableProgressBar()
    {
        waveProgressBar.value = 1f;
        waveProgressBar.enabled = true;
        waveProgressBar.gameObject.SetActive(true);
    }

    public void disableProgressBar()
    {
        waveProgressBar.enabled = false;
        waveProgressBar.gameObject.SetActive(false);
    }
}
