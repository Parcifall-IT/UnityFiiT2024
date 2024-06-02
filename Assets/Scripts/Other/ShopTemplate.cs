using UnityEngine;
using TMPro;
using Image = UnityEngine.UI.Image;


public class ShopTemplate : MonoBehaviour
{
    [SerializeField] public TMP_Text titleText;
    [SerializeField] public  TMP_Text descriptionText;
    [SerializeField] public  TMP_Text priceText;
    public Image image;
}
