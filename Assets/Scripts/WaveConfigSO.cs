using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] float fltTimeBetweenEnemySpawns = 1f;
    [SerializeField] float fltSpawnTimeVariance = 0f;
    [SerializeField] float fltMinimumSpawnTime = .02f;
         
    [SerializeField] Transform pathPrefab;
    [SerializeField] float fltMoveSpeed = 5f;

    public Transform GetStartingWayPoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach(Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }

        return waypoints;
    }

    public float GetMoveSpeed()
    {
        return fltMoveSpeed;
    }

    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemeyPrefab( int intIndex)
    {
        return enemyPrefabs[intIndex];
    }

    public float GetRandomSpawnTime()
    {
        float fltSpawnTime = Random.Range(fltTimeBetweenEnemySpawns - fltSpawnTimeVariance,
            fltSpawnTimeVariance + fltSpawnTimeVariance);
        return Mathf.Clamp(fltSpawnTime, fltMinimumSpawnTime, float.MaxValue);
    }
}
