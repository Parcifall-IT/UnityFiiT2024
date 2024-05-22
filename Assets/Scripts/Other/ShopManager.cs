using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Serialization;

public class ShopManager : MonoBehaviour
{
    //[SerializeField] private int coins;

    [SerializeField] private TMP_Text coinUI;

    [SerializeField] private ShopItemScript[] shopItems;

    [SerializeField] private GameObject[] shopPanelsGameObj;

    [SerializeField] private ShopTemplate[] shopPanels;

    [SerializeField] private Button[] buyButtons;

    [SerializeField] private PlayerHealth playerHealth;

    [SerializeField] private PlayerCoins coins;

    // Start is called before the first frame update
    void Start()
    {
        coins.UpdateCoinsText();
        // for (var i = 0; i < shopItems.Length; i++)
        // {
        //     Debug.Log("show panel: " + i);
        //     shopPanelsGameObj[i].SetActive(true);
        // }
        //coinUI.text = "Coins: " + coins;
        //LoadPanels();
        CheckBuyAbility();
        ShowPanelsByCategory("Health");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void CloseShop()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void BuyItem(int btnNumber)
    {
        if (coins.SpendCoins(shopItems[btnNumber].basePrice))
        {
            Debug.Log("Buy item: " + btnNumber);
            if (shopItems[btnNumber].healthRestored > 0)
                BuyHealthItem(shopItems[btnNumber]);
            coins.UpdateCoinsText();
            CheckBuyAbility();
        }
    }

    private void AddCoins()
    {
        coins.AddCoins(1);
        coins.UpdateCoinsText();
        CheckBuyAbility();
    }
    
    // private void LoadPanels()
    // {
    //     for (var i = 0; i < shopItems.Length; i++)
    //     {
    //         shopPanels[i].titleText.text = shopItems[i].title;
    //         shopPanels[i].descriptionText.text = shopItems[i].description;
    //         shopPanels[i].priceText.text = "Price: " + shopItems[i].basePrice;
    //     }
    // }

    private void CheckBuyAbility()
    {
        for (var i = 0; i < shopItems.Length; i++)
        {
            Debug.Log("btn " + i + " and item price: " + shopItems[i].basePrice);
            buyButtons[i].interactable = coins.currentCoins >= shopItems[i].basePrice;
        }
        
    }

    public void OnHealthTab()
    {
        ShowPanelsByCategory("Health");
    }

    public void OnUpgradesTab()
    {
        ShowPanelsByCategory("Upgrades");
    }

    public void OnAmmoTab()
    {
        ShowPanelsByCategory("Ammo");
    }

    private void ShowPanelsByCategory(string category)
    {
        for (var i = 0; i < shopItems.Length; i++)
        {
            if (shopItems[i].category == category)
            {
                Debug.Log("show panel " + i);
                shopPanelsGameObj[i].SetActive(true);
                shopPanels[i].titleText.text = shopItems[i].title;
                shopPanels[i].descriptionText.text = shopItems[i].description;
                shopPanels[i].priceText.text = "Price: " + shopItems[i].basePrice;
                // shopPanels[i].image = Sprite.Create(shopItems[i].image, new Rect(0,0,shopItems[i].image.width,shopItems[i].image.height), new Vector2(0.5f, 0.5f));
                if (shopItems[i].image != null)
                    shopPanels[i].image.sprite = Sprite.Create(shopItems[i].image,
                        new Rect(0, 0, shopItems[i].image.width, shopItems[i].image.height), new Vector2(0.5f, 0.5f));
                // else
                //     shopPanels[i].image.sprite = null;
            }
            else
                shopPanelsGameObj[i].SetActive(false);
        }
    }

    private void BuyHealthItem(ShopItemScript item)
    {
        playerHealth.RestoreHealth(item.healthRestored);
    }
}