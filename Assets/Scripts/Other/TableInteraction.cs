using UnityEngine;

public class TableInteraction : MonoBehaviour
{
    [SerializeField] private GameObject shopCanvas;
    private bool canOpenShop = false;

    void Update()
    {
        if (!canOpenShop)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            shopCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void CanOpenShopToTrue()
    {
        canOpenShop = true;
    }

    public void CanOpenShopToFalse()
    {
        canOpenShop = false;
    }
}
