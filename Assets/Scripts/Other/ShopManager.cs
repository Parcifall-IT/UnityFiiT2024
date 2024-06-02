﻿using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    //[SerializeField] private int coins;

    [SerializeField] private TMP_Text coinUI;

    [SerializeField] private ShopItemScript[] shopItems;

    [SerializeField] private GameObject[] shopPanelsGameObj;

    [SerializeField] private ShopTemplate[] shopPanels;

    [SerializeField] private Button[] buyButtons;

    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCoins>().UpdateCoinsText();
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
        CheckBuyAbility();
    }

    public void CloseShop()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void BuyItem(int btnNumber)
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCoins>().SpendCoins(shopItems[btnNumber].basePrice))
        {
            var name = shopItems[btnNumber].title;
            Debug.Log("Buy item: " + btnNumber);
            Debug.Log(name);
            if (shopItems[btnNumber].healthRestored > 0)
                BuyHealthItem(shopItems[btnNumber]);
            if (name == "Arrows")
                BuyArrows();
            if (name == "Gun")
            {
                var texture = shopItems[btnNumber].image;
                var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), 
                    new Vector2(0.5f, 0.5f));
                
                BuyNewGun(sprite);
            }
            if (name is "Sword" || name is "Fork")
            {
                var texture = shopItems[btnNumber].image;
                var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),
                    new Vector2(0.5f, 0.5f));
                BuyNewSword(name, sprite);
            }
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCoins>().UpdateCoinsText();
            CheckBuyAbility();
        }
    }

    private void BuyNewSword(string name, Sprite sprite)
    {
        GameObject.FindGameObjectWithTag("Canvas").GetComponent<GameUI>().ChangeMelee(sprite);
        var damage = name == "Sword" ? 6 : 2;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>().ChangeMelee(sprite, damage);
    }

    private void BuyNewGun(Sprite newSprite)
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Audio>().PlayRari();
        GameObject.FindGameObjectWithTag("Canvas").GetComponent<GameUI>().ChangeDistance(newSprite);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>().ChangeGun(newSprite);
    }

    private void BuyArrows()
    {
        GameObject.FindGameObjectWithTag("Gun").GetComponent<Arbalest>().AddArrows();
    }

    private void AddCoins()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCoins>().AddCoins(1);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCoins>().UpdateCoinsText();
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
            buyButtons[i].interactable = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCoins>().GetCoins() >= shopItems[i].basePrice;
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
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().RestoreHealth(item.healthRestored);
    }
}