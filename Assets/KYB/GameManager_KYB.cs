using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_KYB : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public Transform[] enemySpawnPoint;

    public GameObject PortalPrefab;

    public Player player;

    public Text hpText;

    private void Start()
    {
        StartCoroutine(CO_SpawnEnemy());
        StartCoroutine(CO_SpawnPortal());
        player = FindObjectOfType<Player>().GetComponent<Player>();
    }
    private void Update()
    {
        hpText.text = "PLAYER HP \n" + player.hp + " / " + player.maxHp;
    }
    public void spawnEnemy()
    {
        if(Random.Range(0, 2) == 0)
        {
        Instantiate(EnemyPrefab, enemySpawnPoint[0].position, Quaternion.identity);

        }
        else
        {
        Instantiate(EnemyPrefab, enemySpawnPoint[1].position, Quaternion.identity);
        }
    }

    IEnumerator CO_SpawnEnemy()
    {
        while (true)
        {
            spawnEnemy();
            yield return new WaitForSeconds(2.5f);
        }

    }

    IEnumerator CO_SpawnPortal()
    {
        yield return new WaitForSeconds(30f);
        Instantiate(PortalPrefab).transform.position = Vector2.up * 1.5f;
    }
}
