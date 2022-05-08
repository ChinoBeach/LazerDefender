using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveConfigSO currentWave;
    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        for(int intIndex = 0; intIndex < currentWave.GetEnemyCount(); intIndex++)
        {
            Instantiate(currentWave.GetEnemeyPrefab(intIndex),
            currentWave.GetStartingWayPoint().position, Quaternion.identity,
            transform);
        }

        
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }
}
