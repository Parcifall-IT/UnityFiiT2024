using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesTrigger : MonoBehaviour
{
    [SerializeField] GameObject EnemyType;
    [SerializeField] int AmountOfEnemies;
    [SerializeField] string TagFilter;
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minY;
    [SerializeField] float maxY;
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
