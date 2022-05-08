using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float fltTimeBetweenWaves = 0f;
    WaveConfigSO currentWave;

    [SerializeField] bool bolIsLooping;
    void Start()
    {
        StartCoroutine(SpawnEnemiesWaves());
    }

    IEnumerator SpawnEnemiesWaves() 
    {
        do
        {
            foreach (WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                for (int intIndex = 0; intIndex < currentWave.GetEnemyCount(); intIndex++)
                {

                    Instantiate(currentWave.GetEnemeyPrefab(intIndex),
                    currentWave.GetStartingWayPoint().position, Quaternion.identity,
                    transform);

                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(fltTimeBetweenWaves);
            }
        }
        while (bolIsLooping);
        

        
        
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }
}
