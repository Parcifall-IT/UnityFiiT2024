using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;


public class ShopTemplate : MonoBehaviour
{
    [SerializeField] public TMP_Text titleText;
    [SerializeField] public  TMP_Text descriptionText;
    [SerializeField] public  TMP_Text priceText;
    public Image image;
}
