using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //[SerializeField] private GameObject enemy;
    [SerializeField] private GameObject[] enemies;

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
        int randomEnemy = Random.Range(0, enemies.Length);
        spawnTimer = 5f;
        Instantiate(enemies[randomEnemy], transform.position, Quaternion.identity);


    }
}
