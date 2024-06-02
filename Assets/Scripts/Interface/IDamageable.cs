public interface IDamageable
{
    void Damage(float damageAmount);
    float GetHealth();

    bool HasTakenDamage { get; set; }
}