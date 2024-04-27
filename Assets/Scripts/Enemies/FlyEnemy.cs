using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : MonoBehaviour, IDamageable
{

    [SerializeField] private float maxHealth = 5f;
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
            Die();
        }
    }

    public float GetHealth()
    {
        return currentHeath;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
