using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TableOutlineEffect : MonoBehaviour
{
    [SerializeField] private GameObject outline;

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
            }
        }
    }
}