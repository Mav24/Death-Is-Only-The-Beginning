using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    public float spawnTimer = 5f;

    private void Update()
    {
        spawnTimer -= Time.deltaTime;

        if(spawnTimer < 0)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        spawnTimer = 5f;
        Instantiate(enemy, transform.position, Quaternion.identity);
    }
}
