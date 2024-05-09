using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void Damage(float damageAmount);
    float GetHealth();

    bool HasTakenDamage { get; set; }
}