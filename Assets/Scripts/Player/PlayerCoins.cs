using TMPro;
using UnityEngine;

public class PlayerCoins : MonoBehaviour
{
    private int currentCoins;

    [SerializeField] private TMP_Text coinsText;
    // Start is called before the first frame update
    void Start()
    {
        currentCoins = 30;
        UpdateCoinsText();
    }

    public void AddCoins(int amount)
    {
        currentCoins += amount;
        UpdateCoinsText();
    }

    public bool SpendCoins(int amount)
    {
        if (currentCoins >= amount)
        {
            currentCoins -= amount;
            UpdateCoinsText();
            return true;
        }
        return false;
    }

    public void UpdateCoinsText()
    {
        coinsText.text = "Coins: " + currentCoins;
    }

    public int GetCoins()
    {
        return currentCoins;
    }
}
