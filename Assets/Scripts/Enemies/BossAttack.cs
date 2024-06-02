using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] private GameObject EnemyType;
    private float minSpawnTime = 10f;
    private float maxSpawnTime = 20f;

    [SerializeField] float minX = -13;
    [SerializeField] float maxX = 13;
    [SerializeField] float minY = -11;
    [SerializeField] float maxY = 11;
    private float spawnDelay = 1f;
    private float xPos;
    private float yPos;

    void Start()
    {
        Invoke("SpawnEnemy", Random.Range(minSpawnTime, maxSpawnTime));
    }

    void SpawnEnemy()
    {
        var nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        GetComponent<Animator>().SetTrigger("Spawn");

        Invoke("Spawn", spawnDelay);

        // Вызываем метод SpawnEnemy с задержкой в случайное время nextSpawnTime + spawnDelay
        Invoke("Spawn", nextSpawnTime + spawnDelay);
    }

    void Spawn()
    {
        var spawnedEnemies = 0;

        while (spawnedEnemies < 4)
        {
            xPos = Random.Range(minX, maxX);
            yPos = Random.Range(minY, maxY);
            var enemy = Instantiate(EnemyType, new Vector2(xPos, yPos), Quaternion.identity);
            enemy.GetComponent<FlyEnemy>().OnEnemyKilled += HandleEnemyKilled;
            spawnedEnemies++;
        }
    }

    private void HandleEnemyKilled()
    {
    }
}
