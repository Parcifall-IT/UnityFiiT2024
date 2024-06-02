using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEnemiesTrigger : MonoBehaviour
{
    [SerializeField] GameObject EnemyType;
    [SerializeField] GameObject Boss;
    [SerializeField] GameObject bossHealth;
    [SerializeField] int AmountOfEnemies;
    [SerializeField] string TagFilter = "Player";
    [SerializeField] float minX = -8;
    [SerializeField] float maxX = 9;
    [SerializeField] float minY = -11;
    [SerializeField] float maxY = 3;
    [SerializeField] private GameObject pressedButton;
    private float xPos;
    private float yPos;
    private int spawnedEnemies;
    private int aliveEnemies;
    private bool isAbleToSpawn = true;
    private int[] wave = new int[] { 3, 4, 6};
    private int currentWave;

    [SerializeField] private GameObject Tips;

    private void Start()
    {
        pressedButton.SetActive(false);
        currentWave = 0;
        AmountOfEnemies = wave[currentWave];
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
        Tips.GetComponent<ShowTips>().Vanish();
        if (currentWave > 2)
        {
            BossFight();
            return;
        }
        
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
        currentWave++;
        AmountOfEnemies = wave[currentWave % 3];
    }

    private void BossFight()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Audio>().PlayBoss();
        bossHealth.active = true;
        pressedButton.SetActive(true);
        spawnedEnemies = 0;
        AmountOfEnemies = 3;
        aliveEnemies = AmountOfEnemies + 1;

        while (spawnedEnemies < AmountOfEnemies)
        {
            xPos = Random.Range(minX, maxX);
            yPos = Random.Range(minY, maxY);
            var enemy = Instantiate(EnemyType, new Vector2(xPos, yPos), Quaternion.identity);
            enemy.GetComponent<FlyEnemy>().OnEnemyKilled += HandleEnemyKilled;
            spawnedEnemies++;
            isAbleToSpawn = false;
        }

        xPos = Random.Range(minX, maxX);
        yPos = Random.Range(minY, maxY);
        var boss = Instantiate(Boss, new Vector2(xPos, yPos), Quaternion.identity);
        boss.GetComponent<Boss>().OnEnemyKilled += EndBossFight;
    }

    private void HandleEnemyKilled()
    {
        aliveEnemies--;
        if (aliveEnemies <= 0)
        {
            pressedButton.SetActive(false);
            Tips.GetComponent<ShowTips>().Show();
            isAbleToSpawn = true;
        }
    }

    private void EndBossFight()
    {
        foreach (var enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if (enemy.TryGetComponent<FlyEnemy>(out var z))
                z.Die();
            if (enemy.TryGetComponent<Boss>(out var v))
                v.Die();
        }
        
        bossHealth.active = false;
        HandleEnemyKilled();
        Debug.Log("ЕБААААТЬ");
        isAbleToSpawn = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Audio>().PlayFarm();
    }
}