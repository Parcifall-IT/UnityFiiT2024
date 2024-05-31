using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEnemiesTrigger : MonoBehaviour
{
    [SerializeField] GameObject EnemyType;
    [SerializeField] int AmountOfEnemies;
    [SerializeField] string TagFilter = "Player";
    [SerializeField] float minX = -13;
    [SerializeField] float maxX = 13;
    [SerializeField] float minY = -11;
    [SerializeField] float maxY = 11;
    [SerializeField] private GameObject pressedButton;
    private float xPos;
    private float yPos;
    private int spawnedEnemies;
    private int aliveEnemies;
    private bool isAbleToSpawn = true;

    private void Start()
    {
        pressedButton.SetActive(false);
        AmountOfEnemies = 3;
    }

    // private void Update()
    // {
    //     CheckEnemiesStatus();
    // }
    //
    // private void CheckEnemiesStatus()
    // {
    //     var amountOfAliveEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
    //     if (amountOfAliveEnemies == 0 && !isAbleToSpawn)
    //     {
    //         pressedButton.SetActive(false);
    //         isAbleToSpawn = true;
    //     }
    // }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        spawnedEnemies = 0;
        var amountOfAliveEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (amountOfAliveEnemies == 0)
        {
            isAbleToSpawn = true;
        }

        if (!string.IsNullOrEmpty(TagFilter) && !collision.gameObject.CompareTag(TagFilter))
            return;
        if (isAbleToSpawn)
        {
            SpawnEnemies();
            if (isAbleToSpawn)
                pressedButton.SetActive(false);
        }
    }

    void SpawnEnemies()
    {
        pressedButton.SetActive(true);
        spawnedEnemies = 0;
        aliveEnemies = AmountOfEnemies;
        
        while (spawnedEnemies < AmountOfEnemies)
        {
            xPos = Random.Range(minX, maxX);
            yPos = Random.Range(minY, maxY);
            var enemy = Instantiate(EnemyType, new Vector2(xPos, yPos), Quaternion.identity);
            enemy.GetComponent<FlyEnemy>().OnEnemyKilled += HandleEnemyKilled;
            spawnedEnemies++;
            isAbleToSpawn = false;
        }
        AmountOfEnemies += 2;
    }

    private void HandleEnemyKilled()
    {
        aliveEnemies--;
        if (aliveEnemies <= 0)
        {
            pressedButton.SetActive(false);
            isAbleToSpawn = true;
        }
    }
}