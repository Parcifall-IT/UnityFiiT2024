using TMPro;
using UnityEngine;

public class TableOutlineEffect : MonoBehaviour
{
    [SerializeField] private GameObject outline;
    [SerializeField] private GameObject tip;

    void Start()
    {
        if (outline != null)
        {
            outline.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            GetComponent<TableInteraction>().CanOpenShopToTrue();
            if (outline != null)
            {
                outline.GetComponent<SpriteRenderer>().enabled = true;
                tip.active = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GetComponent<TableInteraction>().CanOpenShopToFalse();
            if (outline != null)
            {
                outline.GetComponent<SpriteRenderer>().enabled = false;
                tip.active = false;
            }
        }
    }
}