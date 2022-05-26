using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float spawnInterval = 1f;
    [SerializeField] float spawnIntervalVariance = 0.2f;
    [SerializeField] int numberOfEnemies = 5;


    public GameObject GetEnemyPrefab() { return enemyPrefab; }
    public GameObject GetPathPrefab() { return pathPrefab; }
    public float GetSpawnInterval() { return spawnInterval; }    
    public float GetSpawnIntervalVariance() { return spawnIntervalVariance; }
    public int GetNumberOfEnemies() { return numberOfEnemies; }

    public List<Transform> GetWaypoints() 
    {
        var waypoints = new List<Transform>();

        foreach (Transform child in pathPrefab.transform)
        {
            waypoints.Add(child);
        }

        return waypoints;
    }

}
