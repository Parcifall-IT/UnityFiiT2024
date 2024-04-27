using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppetHealth : MonoBehaviour, IDamageable
{

    [SerializeField] private float maxHealth = float.MaxValue;
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

        DamageUI.Instance.AddText((int)damageAmount, GetComponent<Transform>().position);

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
