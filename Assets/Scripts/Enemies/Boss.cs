using System;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class Boss : MonoBehaviour, IDamageable
{
    public event Action OnEnemyKilled;
    [SerializeField] private float maxHealth = 100f;
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
        GameObject.FindGameObjectWithTag("BossHealth").GetComponent<Image>().fillAmount = currentHeath / maxHealth;
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
        OnEnemyKilled();
        GameObject.FindGameObjectWithTag("BossHealth").GetComponent<Image>().fillAmount = 1;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCoins>().AddCoins(Random.Range(20, 31));
        Destroy(gameObject);
    }
}
