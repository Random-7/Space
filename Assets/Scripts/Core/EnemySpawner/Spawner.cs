using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> stageOneWaveConfigs;
    [SerializeField] List<WaveConfig> stageTwoWaveConfigs;
    [SerializeField] List<WaveConfig> stageThreeWaveConfigs;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAllWaves(stageOneWaveConfigs));
    }

    public void Respawn(int wavecount)
    {
        StopAllCoroutines();
        if(wavecount <= 5)
        {
            StartCoroutine(SpawnAllWaves(stageOneWaveConfigs));
        } else if (wavecount >= 5 && wavecount <= 10)
        {
            StartCoroutine(SpawnAllWaves(stageTwoWaveConfigs));
        } else if (wavecount >= 10)
        {
            StartCoroutine(SpawnAllWaves(stageThreeWaveConfigs));
        }

    }

    private IEnumerator SpawnAllWaves(List<WaveConfig> waveConfigs)
    {
        for (int waveIndex = 0; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var game = FindObjectOfType<Game>();
            game.IncreaseWaveCount(1);
            yield return StartCoroutine(SpawnEnemiesInWave(waveConfigs[waveIndex]));
        }
    }

    private IEnumerator SpawnEnemiesInWave(WaveConfig waveConfig)
    {
        for (int i = 0; i < waveConfig.GetNumberOfEnemies(); i++){
            var spawnedEnemy = Instantiate(waveConfig.GetEnemyPrefab(), waveConfig.GetStartingWaypoint().position, Quaternion.identity);
            spawnedEnemy.GetComponent<EnemyMovement>().SetWaveConfig(waveConfig);
            spawnedEnemy.GetComponent<Enemy>().SetWeapon(waveConfig.GetWeapon());

            yield return new WaitForSeconds(Random.Range(waveConfig.GetSpawnInterval(), 
                (waveConfig.GetSpawnInterval() + waveConfig.GetSpawnIntervalVariance())));
        }
    }
}
