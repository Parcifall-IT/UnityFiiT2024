using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    [SerializeField] private GameObject upgradeMenu;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log("Hit: " + hit.collider.gameObject.name);
                if (hit.collider.gameObject == gameObject)
                {
                    ToggleMenu();
                }
            }
            else
            {
                Debug.Log("No collider hit.");
            }
        }
    }

    void ToggleMenu()
    {
        if (upgradeMenu != null)
        {
            var isActive = !upgradeMenu.activeSelf;
            upgradeMenu.SetActive(isActive);
            Time.timeScale = isActive ? 0 : 1;
            Debug.Log("Menu opened. Active: " + upgradeMenu.activeSelf);
        }
        else
        {
            Debug.LogWarning("Upgrade menu is not assigned.");
        }
    }
}
