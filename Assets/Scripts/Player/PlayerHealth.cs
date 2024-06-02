using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public bool HasTakenDamage { get; set; }
    [SerializeField] private float maxHealth = 10;
    private float currentHeath;

    [SerializeField] private Image healthBar;
    [SerializeField] private GameObject alive;
    [SerializeField] private GameObject dead;
    [SerializeField] private Image blood;
    private EndGameManager endGameManager;


    void Start()
    {
        currentHeath = maxHealth;
        endGameManager = FindObjectOfType<EndGameManager>();
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
            return;
        }
        Debug.Log(128f - 128 * currentHeath / maxHealth);
        blood.GetComponent<Image>().color = new Color(255f, 255f, 255f, (128f - 128 * currentHeath / maxHealth) / 255);
    }

    public float GetHealth()
    {
        return currentHeath;
    }

    private void Die()
    {
        alive.SetActive(false);
        dead.SetActive(true);
        GetComponent<BoxCollider2D>().enabled = false;
        Debug.Log("Man im dead");
        
        if (endGameManager != null)
            endGameManager.ShowEndGameScreen();
        else
            Debug.LogError("EndGameManager not found");
    }

    public void RestoreHealth(int amount)
    {
        currentHeath += amount / maxHealth;
        if (currentHeath > maxHealth)
            currentHeath = maxHealth;
        healthBar.GetComponent<Image>().fillAmount = currentHeath / maxHealth;
    }
}
