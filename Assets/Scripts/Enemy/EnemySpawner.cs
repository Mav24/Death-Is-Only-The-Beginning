using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float delay = 1f;

    public float spawnTimer = 5f;


    private void Start()
    {
        //StartCoroutine(SpawnEnemy());
    }

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

    //IEnumerator SpawnEnemy()
    //{
    //    Instantiate(enemy, transform.position, Quaternion.identity);
    //    yield return new WaitForSeconds(delay);
    //}
}
