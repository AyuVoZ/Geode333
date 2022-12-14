using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform spawnPoint;
    public Wave[] Waves;
    public bool finishedSpawning;
    private int index_wave;
    private bool isSpawning = false;
    private bool isWaiting = false;
    private int timeBetweenWaves = 8;
    private float startTime;
    private int enemySpawned = 0;
    private int enemyIndex = 0;
    private bool firstWave = true;

    [System.Serializable]
    public class Wave
    {
        public GameObject[] EnemyPrefabs;
        public int[] count;
        public float rate;
    }

    private void Awake()
    {
        index_wave = 0;
        startTime = Time.fixedTime;
    }

    private void Update()
    {
        if(firstWave && Time.fixedTime >= 15 + startTime)
        {
            isSpawning = true;
        }
        if (index_wave == Waves.Length)
        {
            finishedSpawning = true;
            return;
        }
        if(isWaiting)
        {
            if (Time.fixedTime >= timeBetweenWaves + startTime)
            {
                enemySpawned = 1;
                enemyIndex = 0;
                SpawnEnemy(Waves[index_wave].EnemyPrefabs[0]);
                isWaiting = false;
                isSpawning = true;
                startTime = Time.fixedTime;
            }
        }
        else if(isSpawning)
        {
            if(enemyIndex == Waves[index_wave].count.Length)
            {
                isSpawning = false;
                isWaiting = true;
                startTime = Time.fixedTime;
                index_wave++;
            }
            else if(enemySpawned == Waves[index_wave].count[enemyIndex])
            {
                enemyIndex++;
                enemySpawned = 0;
            }
            else if (Time.fixedTime >= startTime + Waves[index_wave].rate)
            {
                SpawnEnemy(Waves[index_wave].EnemyPrefabs[enemyIndex]);
                enemySpawned++;
                startTime = Time.fixedTime;
            }
        }
    }

    void SpawnEnemy(GameObject EnemyPrefab)
    {
        Instantiate(EnemyPrefab, spawnPoint.transform.position, Quaternion.identity);
    }
}
