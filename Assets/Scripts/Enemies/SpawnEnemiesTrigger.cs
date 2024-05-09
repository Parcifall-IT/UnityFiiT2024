using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesTrigger : MonoBehaviour
{
    [SerializeField] GameObject EnemyType;
    [SerializeField] int AmountOfEnemies = 1;
    [SerializeField] string TagFilter = "Player";
    [SerializeField] float minX = -13;
    [SerializeField] float maxX = 13;
    [SerializeField] float minY = -11;
    [SerializeField] float maxY = 11;
    private float xPos;
    private float yPos;
    private int spawnedEnemies;
    private bool isAbleToSpawn = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!string.IsNullOrEmpty(TagFilter) && !collision.gameObject.CompareTag(TagFilter))
            return;
        if (isAbleToSpawn)
        {
            SpawnEnemies();
            isAbleToSpawn = false;
        }

        spawnedEnemies = 0;
        isAbleToSpawn = true;
    }

    void SpawnEnemies()
    {
        while (spawnedEnemies < AmountOfEnemies)
        {
            xPos = Random.Range(minX, maxX);
            yPos = Random.Range(minY, maxY);
            Instantiate(EnemyType, new Vector2(xPos, yPos), Quaternion.identity);
            spawnedEnemies++;
        }
    }
}
