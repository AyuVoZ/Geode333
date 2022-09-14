using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform spawnPoint;
    public Wave[] Waves;
    private int index_wave;
    private bool isSpawning = false;
    private bool isWaiting = false;
    private int timeBetweenWaves = 5;
    private float startTime;
    private int enemySpawned = 0;

    [System.Serializable]
    public class Wave
    {
        public GameObject EnemyPrefab;
        public int count;
        public float rate;
    }

    private void Awake()
    {
        index_wave = 0;
        isSpawning = true;
    }

    private void Update()
    {
        if (index_wave == Waves.Length)
        {
            return;
        }
        if(isWaiting)
        {
            if (Time.fixedTime >= timeBetweenWaves + startTime)
            {
                enemySpawned = 1;
                SpawnEnemy(Waves[index_wave].EnemyPrefab);
                isWaiting = false;
                isSpawning = true;
                startTime = Time.fixedTime;
            }
        }
        else if(isSpawning)
        {
            if(enemySpawned == Waves[index_wave].count)
            {
                isSpawning = false;
                isWaiting = true;
                startTime = Time.fixedTime;
                index_wave++;
            }
            else if (Time.fixedTime >= startTime + Waves[index_wave].rate)
            {
                SpawnEnemy(Waves[index_wave].EnemyPrefab);
                enemySpawned++;
                startTime = Time.fixedTime;
            }
        }
    }

    void SpawnWave()
    {
        SpawnEnemy(Waves[index_wave].EnemyPrefab);
    }

    void SpawnEnemy(GameObject EnemyPrefab)
    {
        Instantiate(EnemyPrefab, spawnPoint.transform.position, Quaternion.identity);
    }
}
