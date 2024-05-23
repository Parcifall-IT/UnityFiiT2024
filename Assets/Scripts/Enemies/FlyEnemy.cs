using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : MonoBehaviour, IDamageable
{

    [SerializeField] private float maxHealth = 5f;
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

    private void Die()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCoins>().AddCoins(Random.Range(1, 4));
        Destroy(gameObject);
    }
}
