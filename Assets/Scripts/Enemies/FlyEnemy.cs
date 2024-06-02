using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class FlyEnemy : MonoBehaviour, IDamageable
{
    public event Action OnEnemyKilled;
    [SerializeField] private float maxHealth = 7f;
    //[SerializeField] private PlayerCoins coins;
    //private readonly int coinsToDrop = 10;
    private float currentHeath;
    

    public bool HasTakenDamage { get; set; }

    void Start()
    {
        currentHeath = maxHealth;
    }

    public void Damage(float damageAmount)
    {
        HasTakenDamage = true;
        currentHeath -= damageAmount;

        if (currentHeath <= 0)
        {
            // OnEnemyKilled();
            Die();
        }
    }

    // private void OnEnemyKilled()
    // {
    //     coins.AddCoins( coinsToDrop);
    // }

    public float GetHealth()
    {
        return currentHeath;
    }

    public void Die()
    {
        OnEnemyKilled();
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCoins>().AddCoins(Random.Range(8, 13));
        Destroy(gameObject);
    }
}
