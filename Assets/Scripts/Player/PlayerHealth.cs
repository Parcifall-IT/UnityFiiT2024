using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public bool HasTakenDamage { get; set; }
    [SerializeField] private float maxHealth = 10;
    private float currentHeath;

    [SerializeField] private Image healthBar;

    void Start()
    {
        currentHeath = maxHealth;
    }

    public void Damage(float damageAmount)
    {
        HasTakenDamage = true;
        currentHeath -= damageAmount;

        healthBar.GetComponent<Image>().fillAmount = currentHeath / maxHealth;
        //DamageUI.Instance.AddText((int)damageAmount, GetComponent<Transform>().position);

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
        Debug.Log("Man im dead");
    }
}
