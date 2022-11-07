using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_KYB : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public Transform[] enemySpawnPoint;

    private void Start()
    {
        StartCoroutine(CO_SpawnEnemy());
    }
    public void spawnEnemy()
    {
        Instantiate(EnemyPrefab, enemySpawnPoint[0].position, Quaternion.identity);
        Instantiate(EnemyPrefab, enemySpawnPoint[1].position, Quaternion.identity);
    }

    IEnumerator CO_SpawnEnemy()
    {
        while (true)
        {
            spawnEnemy();
            yield return new WaitForSeconds(8f);
        }

    }
}
