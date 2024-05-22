using UnityEngine;
using UnityEngine.UI;

public class CloseUpgradeMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject upgradeMenu;

    public void CloseUpgradeMenu()
    {
        upgradeMenu.SetActive(false);
        Time.timeScale = 1;
    }
}