using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float fltTimeBetweenWaves = 0f;
    WaveConfigSO currentWave;
    [SerializeField] int intWaveNumber = 0;

    [SerializeField] bool bolIsLooping;
    void Start()
    {
        StartCoroutine(SpawnEnemiesWaves());
    }

    IEnumerator SpawnEnemiesWaves() 
    {
        intWaveNumber = 1;
        do
        {
            foreach (WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                for (int intIndex = 0; intIndex < currentWave.GetEnemyCount(); intIndex++)
                {

                    Instantiate(currentWave.GetEnemeyPrefab(intIndex),
                    currentWave.GetStartingWayPoint().position, Quaternion.Euler(0,0,180),
                    transform);

                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(fltTimeBetweenWaves);
                intWaveNumber += 1;
            }
        }
        while (bolIsLooping);
        
    }
    public int GetCurrentWaveNumber()
    {
        return intWaveNumber;
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }
}
