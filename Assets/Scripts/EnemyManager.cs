using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject EnemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    void OnEnable()
    {
        EnemyController.OnEnemyKilled += SpawnEnemy;
    }

    void SpawnEnemy()
    {
        Instantiate(EnemyPrefab, spawnPoint.transform.position, Quaternion.identity);
    }
}
