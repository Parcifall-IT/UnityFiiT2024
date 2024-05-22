using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Scriptable Objects/New shop item", order = 1)] 
public class ShopItemScript : ScriptableObject
{
    [SerializeField] public string title;

    [SerializeField] public string description;

    [SerializeField] public int basePrice;

    [SerializeField] public string category;

    [SerializeField] public int healthRestored;

    [SerializeField] public Texture2D image;
}
