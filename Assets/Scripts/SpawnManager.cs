using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject powerupPrefab;
    private float spawnBound = 9;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave3(waveNumber);
        Instantiate(powerupPrefab, GenerateRandomSpawnLocation(), powerupPrefab.transform.rotation);
        //Instantiate(enemyPrefab, GenerateRandomSpawnLocation(), enemyPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0)
        {
            waveNumber++;
            
            Instantiate(powerupPrefab, GenerateRandomSpawnLocation(), powerupPrefab.transform.rotation);
            SpawnEnemyWave3(waveNumber);
        }
    }

    private Vector3 GenerateRandomSpawnLocation()
    {
        float spawnPointX = Random.Range(-spawnBound, spawnBound);
        float spawnPointZ = Random.Range(-spawnBound, spawnBound);
        Vector3 randomLocation = new Vector3(spawnPointX, 0, spawnPointZ);
        return randomLocation;
    }

    void SpawnEnemyWave3(int enemySpawnCount)
    {
        for (int i = 0; i < enemySpawnCount; i++)
        {
            Instantiate(enemyPrefab, GenerateRandomSpawnLocation(), enemyPrefab.transform.rotation);
        }
    }
}
